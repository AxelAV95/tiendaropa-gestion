using AutoMapper;
using MediatR;
using TIENDAROPA.Application.Commons.Bases;
using TIENDAROPA.Application.DTOs.Product;
using TIENDAROPA.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetProductSalesHistoryQuery
{
    public class GetProductSalesHistoryQueryHandler : IRequestHandler<GetProductSalesHistoryQuery, BaseResponse<ProductSalesHistoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductSalesHistoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ProductSalesHistoryDto>> Handle(GetProductSalesHistoryQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ProductSalesHistoryDto>();
            try
            {
                var product = await _unitOfWork.Products.GetByIdAsync(request.ProductId);
                if (product is null)
                {
                    response.IsSuccess = false;
                    response.Message = "Producto no encontrado.";
                    return response;
                }

                var saleItems = await _unitOfWork.Products.GetSalesHistoryAsync(
                    request.ProductId,
                    request.DateRange.StartDate,
                    request.DateRange.EndDate
                );

                var historyDto = new ProductSalesHistoryDto
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ProductCode = product.Code,
                    Sales = _mapper.Map<List<SaleRecordDto>>(saleItems)
                };

                response.Data = historyDto;
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa.";
            }
            catch (System.Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Ocurrió un error en la consulta: " + ex.Message;
            }
            return response;
        }
    }
}