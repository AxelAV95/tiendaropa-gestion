using FluentValidation;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetProductsByBrandQuery
{
    public class GetProductsByBrandQueryValidator : AbstractValidator<GetProductsByBrandQuery>
    {
        public GetProductsByBrandQueryValidator()
        {
            RuleFor(p => p.BrandId)
                .GreaterThan(0).WithMessage("El Id de la marca debe ser un número positivo.");

            RuleFor(p => p.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("El número de página debe ser al menos 1.");

            RuleFor(p => p.PageSize)
                .GreaterThan(0).WithMessage("El tamaño de la página debe ser un número positivo.")
                .LessThanOrEqualTo(100).WithMessage("El tamaño de página no puede exceder los 100 registros.");
        }
    }
}