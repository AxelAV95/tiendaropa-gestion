using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using TIENDAROPA.Application.Commons.Bases;
using TIENDAROPA.Application.DTOs.Product;
using TIENDAROPA.Application.Interfaces.Persistence; // <-- Cambiaremos esto
using TIENDAROPA.Application.Interfaces.Services;

namespace TIENDAROPA.Application.UseCases.ProductVariants.Queries.GetProductVariantBySkuQuery
{
    public class GetProductVariantBySkuQueryHandler : IRequestHandler<GetProductVariantBySkuQuery, BaseResponse<ProductVariantDto>>
    {
        // Nota: Crearemos un repositorio específico para ProductVariant
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductVariantBySkuQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ProductVariantDto>> Handle(GetProductVariantBySkuQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ProductVariantDto>();
            try
            {
                var variant = await _unitOfWork.ProductVariants.GetVariantBySkuAsync(request.Sku);

                if (variant is null)
                {
                    response.IsSuccess = false;
                    response.Message = "Variante de producto no encontrada.";
                    return response;
                }

                response.Data = _mapper.Map<ProductVariantDto>(variant);
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