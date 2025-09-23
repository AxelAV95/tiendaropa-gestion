using FluentValidation;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetProductSalesHistoryQuery
{
    public class GetProductSalesHistoryQueryValidator : AbstractValidator<GetProductSalesHistoryQuery>
    {
        public GetProductSalesHistoryQueryValidator()
        {
            RuleFor(p => p.ProductId)
                .GreaterThan(0).WithMessage("El Id del producto debe ser un número positivo.");

            RuleFor(p => p.DateRange.EndDate)
                .GreaterThanOrEqualTo(p => p.DateRange.StartDate)
                .WithMessage("La fecha final debe ser mayor o igual a la fecha inicial.");
        }
    }
}