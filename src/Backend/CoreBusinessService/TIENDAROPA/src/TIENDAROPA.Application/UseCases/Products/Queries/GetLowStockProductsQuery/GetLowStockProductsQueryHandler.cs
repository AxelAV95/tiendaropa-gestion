using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIENDAROPA.Application.Commons.Bases;
using TIENDAROPA.Application.DTOs.Product;
using TIENDAROPA.Application.Interfaces.Persistence;
using TIENDAROPA.Application.Interfaces.Services;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetLowStockProductsQuery
{
    public class GetLowStockProductsQueryHandler : IRequestHandler<GetLowStockProductsQuery, BaseResponse<List<LowStockProductDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLowStockProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<LowStockProductDto>>> Handle(GetLowStockProductsQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<LowStockProductDto>>();
            try
            {
                // Llamaremos a un nuevo método en el repositorio
                var variants = await _unitOfWork.Products.GetLowStockProductsAsync(request.MinStock);

                response.Data = _mapper.Map<List<LowStockProductDto>>(variants);
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Ocurrió un error en la consulta: " + ex.Message;
            }
            return response;
        }
    }
}