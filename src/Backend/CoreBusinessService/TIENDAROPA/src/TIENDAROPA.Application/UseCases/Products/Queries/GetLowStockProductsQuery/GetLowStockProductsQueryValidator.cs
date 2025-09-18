using FluentValidation;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetLowStockProductsQuery
{
    public class GetLowStockProductsQueryValidator : AbstractValidator<GetLowStockProductsQuery>
    {
        public GetLowStockProductsQueryValidator()
        {
            RuleFor(p => p.MinStock)
                .GreaterThanOrEqualTo(0).WithMessage("El stock mínimo no puede ser negativo.")
                .When(p => p.MinStock.HasValue); // La regla solo se aplica si se proporciona un valor.
        }
    }
}