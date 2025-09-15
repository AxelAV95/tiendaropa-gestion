using MediatR;
using TIENDAROPA.Application.Commons.Bases;
using TIENDAROPA.Application.DTOs.Product;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetProductByIdQuery
{
    public class GetProductByIdQuery : IRequest<BaseResponse<ProductDetailDto>>
    {
        public int ProductId { get; set; }
    }
}
