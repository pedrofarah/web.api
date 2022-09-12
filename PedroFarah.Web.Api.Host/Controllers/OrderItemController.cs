using MediatR;
using Microsoft.AspNetCore.Mvc;
using PedroFarah.Web.Api.Domain.Commands;

namespace PedroFarah.Web.Api.Host.Controllers
{

    public class OrderItemController : BaseController
    {
        public OrderItemController(IMediator mediator) : base(mediator) { }

        // POST api/<OrderItemController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOrderItemCommand orderItem) => Ok(await this.mediator.Send(orderItem));

        // DELETE api/<OrderItemController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id) => Ok(await this.mediator.Send(new DeleteOrderItemCommand { Id = id }));
    }
}
