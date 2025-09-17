using AutoMapper;
using MediatR;
using TIENDAROPA.Application.Commons.Bases;
using TIENDAROPA.Application.DTOs.Product;
using TIENDAROPA.Application.Interfaces.Services; // Corregido: Debe ser Interfaces.Persistence
using System.Collections.Generic;
using System.Linq;

namespace TIENDAROPA.Application.UseCases.Products.Queries.GetProductVariantsQuery
{
    public class GetProductVariantsQueryHandler : IRequestHandler<GetProductVariantsQuery, BaseResponse<List<ProductVariantDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductVariantsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<ProductVariantDto>>> Handle(GetProductVariantsQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<ProductVariantDto>>();

            try
            {
                // Este método lo crearemos en la Fase 3
                var variants = await _unitOfWork.Products.GetVariantsByProductIdAsync(request.ProductId);

                if (variants is null || !variants.Any())
                {
                    response.IsSuccess = true; // La operación fue exitosa, pero no hay contenido
                    response.Message = "El producto no tiene variantes registradas o el producto no existe.";
                    response.Data = new List<ProductVariantDto>(); // Devolver lista vacía
                    return response;
                }

                // Mapeamos la lista de entidades a una lista de DTOs
                response.Data = _mapper.Map<List<ProductVariantDto>>(variants);
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