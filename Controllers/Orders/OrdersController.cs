using AutoMapper;
using JDPodrozeAPI.Controllers.Orders.Contracts;
using JDPodrozeAPI.Core.Enums;
using JDPodrozeAPI.Services;
using JDPodrozeAPI.Services.Orders.Contracts.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JDPodrozeAPI.Controllers.Orders
{
    [Authorize(Roles = "ADMINISTRATOR")]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class OrdersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrdersService _ordersService;

        public OrdersController(IMapper mapper, IOrdersService ordersService)
        {
            _mapper = mapper;
            _ordersService = ordersService;
        }

        [HttpGet("GetList")]
        [ProducesResponseType(typeof(List<OrdersServiceGetListItemRes>), (int) HttpStatusCode.OK)]
        public IActionResult GetList()
        {
            List<OrdersServiceGetListItemRes> res = _ordersService.GetList();
            return Ok(res);
        }

        [HttpPost("ChangePaymentStatus/{OrderId}")]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
        public IActionResult ChangePaymentStatus(Guid OrderId, [FromBody] OrdersChangePaymentStatusReq request)
        {
            _ordersService.ChangePaymentStatus(OrderId, (PaymentStatus) request.Status);
            return Ok();
        }
    }
}