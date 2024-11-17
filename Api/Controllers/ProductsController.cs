using Application.Features.Anemic.Products.Queries;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Products;
using ViewModels.Shared;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ApiControllerBase
    {
        [HttpPost("FetchAll")]
        public async Task<IActionResult> Get(PublicViewModel inputParamsViewModel, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new ProductGetQuery(inputParamsViewModel));
            return Ok(result);
        }

        [HttpGet("GetDapper")]
        public async Task<IActionResult> GetDapper(ProductInputParamsViewModel productInputParamsViewModel)
        {
            var result = await Mediator.Send(new ProductDapperGetQuery(productInputParamsViewModel));
            return Ok(result);
        }
    }
}
