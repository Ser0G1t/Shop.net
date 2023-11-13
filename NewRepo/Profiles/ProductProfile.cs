using AutoMapper;
using NewRepo.DTO;
using NewRepo.Entity;

namespace NewRepo.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
