using MediatR;
using TIENDAROPA.Application.Commons.Bases;
using TIENDAROPA.Application.DTOs.Common;
using TIENDAROPA.Application.DTOs.Product;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetProductsByBrandQuery
{
    // La respuesta es idéntica a la de categoría: un resultado paginado de resúmenes de producto
    public class GetProductsByBrandQuery : IRequest<BaseResponse<PaginatedResultDto<ProductSummaryDto>>>
    {
        public int BrandId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}