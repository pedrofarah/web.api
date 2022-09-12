using MediatR;
using Microsoft.AspNetCore.Mvc;
using PedroFarah.Web.Api.Domain.Commands;
using PedroFarah.Web.Api.Domain.Queries;

namespace PedroFarah.Web.Api.Host.Controllers
{

    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator) : base(mediator) { }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id) => Ok(await this.mediator.Send(new GetOrderQuery { Id = id }));

        // GET: api/<OrderController>
        [HttpPost("GetOrders")]
        public async Task<IActionResult> GetOrders([FromBody] OrderListQuery value)
        {
            var result = await this.mediator.Send(value);
            return Ok(result);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOrderCommand order) => Ok(await this.mediator.Send(order));

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id) => Ok(await this.mediator.Send(new DeleteOrderCommand { Id = id }));

    }
}
