
using Application.Interfaces;
using Domain.Core.Bus;
using Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace susi_app.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(
            ICustomerAppService customerAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _customerAppService = customerAppService;
        }
        

        [HttpGet]
        [AllowAnonymous]
        [Route("GetAll")]
        public JsonResult Get()
        {

            var teste = _customerAppService.GetAll();
            JsonResult jsonResult = new JsonResult(teste);

            return jsonResult;
        }

    }
}
