using AutoMapper;
using TIENDAROPA.Application.DTOs.Product;
using TIENDAROPA.Domain.Entities;

namespace TIENDAROPA.Application.Mappings
{
    public class SalesMapping : Profile
    {
        public SalesMapping()
        {
            CreateMap<SaleItem, SaleRecordDto>()
                .ForMember(dest => dest.SaleId, opt => opt.MapFrom(src => src.SaleId))
                .ForMember(dest => dest.SaleDate, opt => opt.MapFrom(src => src.Sale.SaleDate))
                .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.ProductVariant.Sku))
                .ForMember(dest => dest.QuantitySold, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal));
        }
    }
}