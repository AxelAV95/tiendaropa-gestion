using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIENDAROPA.Application.Commons.Bases;
using TIENDAROPA.Application.DTOs.Common;
using TIENDAROPA.Application.DTOs.Product;
using TIENDAROPA.Application.Interfaces.Persistence;
using TIENDAROPA.Application.Interfaces.Services;

namespace TIENDAROPA.Application.UseCases.Products.Queries.SearchProductsQuery
{
    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, BaseResponse<PaginatedResultDto<ProductSummaryDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SearchProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<PaginatedResultDto<ProductSummaryDto>>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<PaginatedResultDto<ProductSummaryDto>>();
            try
            {
                // Llamaremos a un nuevo método de búsqueda en el repositorio
                var (products, totalCount) = await _unitOfWork.Products.SearchProductsPaginatedAsync(
                    request.SearchCriteria,
                    request.Pagination
                );

                var productSummaries = _mapper.Map<List<ProductSummaryDto>>(products);

                var paginatedResult = new PaginatedResultDto<ProductSummaryDto>
                {
                    Items = productSummaries,
                    TotalCount = totalCount,
                    PageNumber = request.Pagination.PageNumber,
                    TotalPages = (int)Math.Ceiling(totalCount / (double)request.Pagination.PageSize)
                };

                response.Data = paginatedResult;
                response.IsSuccess = true;
                response.Message = "Búsqueda Exitosa.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Ocurrió un error en la búsqueda: " + ex.Message;
            }
            return response;
        }
    }
}