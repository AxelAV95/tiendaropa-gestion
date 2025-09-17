using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIENDAROPA.Application.Commons.Bases;
using TIENDAROPA.Application.DTOs.Common;
using TIENDAROPA.Application.DTOs.Product;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetProductsByCategoryQuery
{
    public class GetProductsByCategoryQuery : IRequest<BaseResponse<PaginatedResultDto<ProductSummaryDto>>>
    {
        public int CategoryId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
