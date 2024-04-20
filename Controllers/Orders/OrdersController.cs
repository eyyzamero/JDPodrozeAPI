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

        [HttpPost]
        [ProducesResponseType(typeof(IOrdersServiceGetListRes), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetList([FromBody] OrdersGetListReq request)
        {
            IOrdersServiceGetListRes response = await _ordersService.GetList(request);
            return Ok(response);
        }

        [HttpGet("GetExcursionOrdersWithDetails/{excursionId}")]
        public async Task<IActionResult> GetExcursionOrdersWithDetails(int excursionId)
        {
            IOrdersGetExcursionOrdersWithDetailsRes response = await _ordersService.GetExcursionOrdersWithDetails(excursionId);
            return Ok(response);
        }

        [HttpPost("ChangePaymentStatus/{OrderId}")]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> ChangePaymentStatus(Guid OrderId, [FromBody] OrdersChangePaymentStatusReq request)
        {
            await _ordersService.ChangePaymentStatus(OrderId, (PaymentStatus) request.Status);
            return Ok();
        }

        [HttpDelete("DeleteParticipant/{participantId}")]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteParticipant(int participantId)
        {
            await _ordersService.DeleteParticipant(participantId);
            return Ok();
        }
    }
}