using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIENDAROPA.Application.Commons.Bases;
using TIENDAROPA.Application.DTOs.Product;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetProductVariantsQuery
{
    public class GetProductVariantsQuery : IRequest<BaseResponse<List<ProductVariantDto>>>
    {
        public int ProductId { get; set; }
    }
}
