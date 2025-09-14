using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TIENDAROPA.Application.UseCases.Products.Queries.GetAllQuery;

namespace TIENDAROPA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("List")]
        public async Task<IActionResult> ProductList()
        {
            var response = await _sender.Send(new GetAllProductQuery());
            return Ok(response);
        }
    }
}
