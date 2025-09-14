using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIENDAROPA.Application.Commons.Bases;
using TIENDAROPA.Application.DTOs.Product;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetAllQuery
{
    public class GetAllProductQuery : IRequest<BaseResponse<IEnumerable<ProductDtoResponse>>>
    {
        //Aquí irían filtros o demas personalizaciones
    }
}
