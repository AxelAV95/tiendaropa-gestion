using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIENDAROPA.Application.Commons.Bases;
using TIENDAROPA.Application.DTOs.Product;
using TIENDAROPA.Application.Interfaces.Services;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetAllQuery
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, BaseResponse<IEnumerable<ProductDtoResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<ProductDtoResponse>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<ProductDtoResponse>>();

            try
            {
                var products = await _unitOfWork.Products.GetAllProductsWithDetailsAsync();

                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<ProductDtoResponse>>(products);
                response.Message = "Consulta exitosa.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
