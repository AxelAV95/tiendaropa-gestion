// TIENDAROPA.Application/UseCases/Products/Queries/GetProductByIdQuery/GetProductByIdQueryHandler.cs

using AutoMapper;
using MediatR;
using TIENDAROPA.Application.Commons.Bases;
// 1. Asegúrate de que el using apunta al DTO correcto.
using TIENDAROPA.Application.DTOs.Product;
using TIENDAROPA.Application.Interfaces.Services;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetProductByIdQuery
{
    // 2. Cambia el tipo de dato de la respuesta a BaseResponse<ProductDetailDto>
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, BaseResponse<ProductDetailDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ProductDetailDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            // 3. La variable de respuesta ahora debe ser de tipo BaseResponse<ProductDetailDto>
            var response = new BaseResponse<ProductDetailDto>();

            try
            {
                var product = await _unitOfWork.Products.GetProductWithDetailsByIdAsync(request.ProductId);

                if (product is null)
                {
                    response.IsSuccess = false;
                    response.Message = "Producto no encontrado.";
                    return response;
                }

                // 4. Usa AutoMapper para mapear al DTO correcto: ProductDetailDto
                response.Data = _mapper.Map<ProductDetailDto>(product);
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