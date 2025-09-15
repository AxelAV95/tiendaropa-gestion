using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetProductByIdQuery
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(p => p.ProductId)
                .NotEmpty().WithMessage("El Id del producto no puede estar vacío.")
                .GreaterThan(0).WithMessage("El Id del producto debe ser un número positivo.");
        }
    }
}
