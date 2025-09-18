using AutoMapper;
using MediatR;
using TIENDAROPA.Application.Commons.Bases;
using TIENDAROPA.Application.DTOs.Common;
using TIENDAROPA.Application.DTOs.Product;
using TIENDAROPA.Application.Interfaces.Services;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetProductsByBrandQuery
{
    public class GetProductsByBrandQueryHandler : IRequestHandler<GetProductsByBrandQuery, BaseResponse<PaginatedResultDto<ProductSummaryDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductsByBrandQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<PaginatedResultDto<ProductSummaryDto>>> Handle(GetProductsByBrandQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<PaginatedResultDto<ProductSummaryDto>>();
            try
            {
                // Llamaremos a un nuevo método en el repositorio
                var (products, totalCount) = await _unitOfWork.Products.GetByBrandPaginatedAsync(
                    request.BrandId,
                    request.PageNumber,
                    request.PageSize
                );

                var productSummaries = _mapper.Map<List<ProductSummaryDto>>(products);

                var paginatedResult = new PaginatedResultDto<ProductSummaryDto>
                {
                    Items = productSummaries,
                    TotalCount = totalCount,
                    PageNumber = request.PageNumber,
                    TotalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize)
                };

                response.Data = paginatedResult;
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