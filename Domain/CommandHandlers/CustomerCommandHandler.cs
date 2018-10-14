
using Domain.Commands;
using Domain.Core.Bus;
using Domain.Core.Notifications;
using Domain.Events;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.CommandHandlers
{
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCustomerCommand>,
        IRequestHandler<UpdateCustomerCommand>,
        IRequestHandler<RemoveCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler Bus;

        public CustomerCommandHandler(ICustomerRepository customerRepository, 
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _customerRepository = customerRepository;
            Bus = bus;
        }

        public Task Handle(RegisterNewCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var customer = new Customer(Guid.NewGuid(), message.Name, message.Email, message.BirthDate);

            if (_customerRepository.GetByEmail(customer.Email) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
                return Task.CompletedTask;
            }
            
            _customerRepository.Add(customer);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
            }

            return Task.CompletedTask;
        }

        public Task Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var customer = new Customer(message.Id, message.Name, message.Email, message.BirthDate);
            var existingCustomer = _customerRepository.GetByEmail(customer.Email);

            if (existingCustomer != null && existingCustomer.Id != customer.Id)
            {
                if (!existingCustomer.Equals(customer))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType,"The customer e-mail has already been taken."));
                    return Task.CompletedTask;
                }
            }

            _customerRepository.Update(customer);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
            }

            return Task.CompletedTask;
        }

        public Task Handle(RemoveCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _customerRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerRemovedEvent(message.Id));
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }

        Task<Unit> IRequestHandler<RegisterNewCustomerCommand, Unit>.Handle(RegisterNewCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Unit> IRequestHandler<UpdateCustomerCommand, Unit>.Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Unit> IRequestHandler<RemoveCustomerCommand, Unit>.Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}