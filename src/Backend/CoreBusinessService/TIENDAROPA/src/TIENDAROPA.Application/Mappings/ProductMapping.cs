using AutoMapper;
using TIENDAROPA.Application.DTOs.Product;
using TIENDAROPA.Domain.Entities;


namespace TIENDAROPA.Application.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            // Instrucción única para convertir la entidad Product al DTO ProductDtoResponse
            CreateMap<Product, ProductDtoResponse>()
                .ForMember(
                    dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category.Name)
                )
                .ForMember(
                    dest => dest.BrandName,
                    opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : null)
                    // Una forma más moderna y corta de escribir lo de arriba es:
                    // opt => opt.MapFrom(src => src.Brand?.Name)
                );

            CreateMap<Product, ProductDetailDto>()
                .ForMember(
                    dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category.Name)
                )
                .ForMember(
                    dest => dest.BrandName,
                    // Usamos el operador de nulidad '?' para evitar errores si la marca es nula.
                    opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : null)
                );
        }

    }
}
