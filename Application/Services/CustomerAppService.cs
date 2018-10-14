using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.EventSourcedNormalizers;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Commands;
using Domain.Core.Bus;
using Domain.Interfaces;

namespace Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler Bus;

        public CustomerAppService(IMapper mapper,
                                  ICustomerRepository customerRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            Bus = bus;
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            //var id = Guid.Parse(_identity.GetUserId());
            //var model = await _freelancerProfiles
            //    .AsNoTracking()
            //    .Where(_ => _.User.Id == id)
            //    .ProjectTo<FreelancerProfileViewModel>(_mapper.Configuration)
            //    .FirstAsync();

            return _customerRepository.GetAll().ProjectTo<CustomerViewModel>(_mapper.ConfigurationProvider);
        }

        public CustomerViewModel GetById(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(_customerRepository.GetById(id));
        }

        public void Register(CustomerViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(customerViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveCustomerCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IList<CustomerHistoryData> GetAllHistory(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
