using MediatR;
using TIENDAROPA.Application.Commons.Bases;
using TIENDAROPA.Application.DTOs.Product; // Reutilizamos el ProductVariantDto

namespace TIENDAROPA.Application.UseCases.ProductVariants.Queries.GetProductVariantBySkuQuery
{
    public class GetProductVariantBySkuQuery : IRequest<BaseResponse<ProductVariantDto>>
    {
        public string Sku { get; set; } = string.Empty;
    }
}