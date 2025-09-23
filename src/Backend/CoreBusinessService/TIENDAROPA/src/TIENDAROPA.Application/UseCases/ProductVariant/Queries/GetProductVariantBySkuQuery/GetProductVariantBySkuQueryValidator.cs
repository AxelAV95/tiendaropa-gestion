using FluentValidation;

namespace TIENDAROPA.Application.UseCases.ProductVariants.Queries.GetProductVariantBySkuQuery
{
    public class GetProductVariantBySkuQueryValidator : AbstractValidator<GetProductVariantBySkuQuery>
    {
        public GetProductVariantBySkuQueryValidator()
        {
            RuleFor(p => p.Sku)
                .NotEmpty().WithMessage("El SKU no puede estar vacío.");
        }
    }
}