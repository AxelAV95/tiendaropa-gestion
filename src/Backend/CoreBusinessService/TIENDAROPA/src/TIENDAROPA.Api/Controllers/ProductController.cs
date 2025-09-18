using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TIENDAROPA.Application.DTOs.Common;
using TIENDAROPA.Application.UseCases.Products.Queries.GetAllQuery;
using TIENDAROPA.Application.UseCases.Products.Queries.GetProductByIdQuery;
using TIENDAROPA.Application.UseCases.Products.Queries.GetProductsByBrandQuery;
using TIENDAROPA.Application.UseCases.Products.Queries.GetProductsByCategoryQuery;
using TIENDAROPA.Application.UseCases.Products.Queries.GetProductVariantsQuery;

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

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            // 1. Crea la consulta con el ID que viene de la URL.
            var query = new GetProductByIdQuery { ProductId = productId };

            // 2. Envía la consulta a MediatR.
            var response = await _sender.Send(query);

            // 3. Devuelve la respuesta apropiada según el resultado.
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            // Si IsSuccess es false (por no encontrar el producto), devolvemos un 404.
            return NotFound(response);
        }

        [HttpGet("{productId}/variants")]
        public async Task<IActionResult> GetVariantsByProduct(int productId)
        {
            var query = new GetProductVariantsQuery { ProductId = productId };
            var response = await _sender.Send(query);

            if (!response.IsSuccess || response.Data == null)
            {
                // Aunque IsSuccess sea true, si Data es null o está vacío, 
                // se puede considerar un 200 OK con una lista vacía.
                // Devolver NotFound si el producto en sí no existe sería otra opción.
                return Ok(response);
            }

            return Ok(response);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId, [FromQuery] PaginationDto pagination)
        {
            var query = new GetProductsByCategoryQuery
            {
                CategoryId = categoryId,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };

            var response = await _sender.Send(query);

            return Ok(response);
        }

        [HttpGet("brand/{brandId}")]
        public async Task<IActionResult> GetProductsByBrand(int brandId, [FromQuery] PaginationDto pagination)
        {
            var query = new GetProductsByBrandQuery
            {
                BrandId = brandId,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };

            var response = await _sender.Send(query);

            return Ok(response);
        }
    }
}
