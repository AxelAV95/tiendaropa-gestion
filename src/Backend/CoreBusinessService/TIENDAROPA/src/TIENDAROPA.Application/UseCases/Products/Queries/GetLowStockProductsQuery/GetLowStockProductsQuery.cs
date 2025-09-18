using MediatR;
using TIENDAROPA.Application.Commons.Bases;
using TIENDAROPA.Application.DTOs.Product;
using System.Collections.Generic;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetLowStockProductsQuery
{
    public class GetLowStockProductsQuery : IRequest<BaseResponse<List<LowStockProductDto>>>
    {
        // El umbral es opcional. Si es nulo, se usará el MinStock de cada producto.
        public int? MinStock { get; set; }
    }
}