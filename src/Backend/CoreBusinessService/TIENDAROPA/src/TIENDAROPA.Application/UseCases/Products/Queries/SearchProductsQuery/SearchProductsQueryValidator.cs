using FluentValidation;
using TIENDAROPA.Application.DTOs.Common;
using TIENDAROPA.Application.DTOs.Product;

namespace TIENDAROPA.Application.UseCases.Products.Queries.SearchProductsQuery
{
    public class SearchProductsQueryValidator : AbstractValidator<SearchProductsQuery>
    {
        public SearchProductsQueryValidator()
        {
            // Validar el objeto de paginación
            RuleFor(p => p.Pagination.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("El número de página debe ser al menos 1.");

            RuleFor(p => p.Pagination.PageSize)
                .GreaterThan(0).WithMessage("El tamaño de la página debe ser un número positivo.")
                .LessThanOrEqualTo(100).WithMessage("El tamaño de página no puede exceder los 100 registros.");

            // Validar el objeto de búsqueda
            When(p => p.SearchCriteria.MinPrice.HasValue && p.SearchCriteria.MaxPrice.HasValue, () =>
            {
                RuleFor(p => p.SearchCriteria.MaxPrice)
                    .GreaterThanOrEqualTo(p => p.SearchCriteria.MinPrice)
                    .WithMessage("El precio máximo no puede ser menor que el precio mínimo.");
            });
        }
    }
}