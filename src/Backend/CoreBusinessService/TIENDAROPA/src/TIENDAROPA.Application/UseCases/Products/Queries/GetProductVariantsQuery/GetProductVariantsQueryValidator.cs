using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetProductVariantsQuery
{
    public class GetProductVariantsQueryValidator : AbstractValidator<GetProductVariantsQuery>
    {
        public GetProductVariantsQueryValidator()
        {
            RuleFor(p => p.ProductId)
                .NotEmpty().WithMessage("El Id del producto no puede estar vacío.")
                .GreaterThan(0).WithMessage("El Id del producto debe ser un número positivo.");
        }

    }

}
