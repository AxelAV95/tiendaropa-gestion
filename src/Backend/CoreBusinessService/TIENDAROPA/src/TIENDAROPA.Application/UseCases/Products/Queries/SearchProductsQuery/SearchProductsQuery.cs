using MediatR;
using TIENDAROPA.Application.Commons.Bases;
using TIENDAROPA.Application.DTOs.Common;
using TIENDAROPA.Application.DTOs.Product;

namespace TIENDAROPA.Application.UseCases.Products.Queries.SearchProductsQuery
{
    public class SearchProductsQuery : IRequest<BaseResponse<PaginatedResultDto<ProductSummaryDto>>>
    {
        // Contiene los filtros de búsqueda (nombre, precio, etc.)
        public ProductSearchDto SearchCriteria { get; set; } = new ProductSearchDto();

        // Contiene los parámetros de paginación (PageNumber, PageSize)
        public PaginationDto Pagination { get; set; } = new PaginationDto();
    }
}