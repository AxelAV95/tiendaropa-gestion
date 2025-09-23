using MediatR;
using TIENDAROPA.Application.Commons.Bases;
using TIENDAROPA.Application.DTOs.Common;
using TIENDAROPA.Application.DTOs.Product;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetProductSalesHistoryQuery
{
    public class GetProductSalesHistoryQuery : IRequest<BaseResponse<ProductSalesHistoryDto>>
    {
        public int ProductId { get; set; }
        public DateRangeDto DateRange { get; set; } = new DateRangeDto();
    }
}