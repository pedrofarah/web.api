using MediatR;
using Microsoft.AspNetCore.Mvc;
using PedroFarah.Web.Api.Domain.Queries;

namespace PedroFarah.Web.Api.Host.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? productName, int records, int offSet)
        {
            var result = await this.mediator.Send(new ProductListQuery 
            { 
                OffSet = offSet, 
                ProductName = productName ?? String.Empty, 
                Records = records 
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id) => Ok(await this.mediator.Send(new GetProductQuery { Id = id }));

    }
}
