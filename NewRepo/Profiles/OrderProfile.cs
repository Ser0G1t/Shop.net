using AutoMapper;
using NewRepo.DTO;
using NewRepo.Entity;

namespace NewRepo.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile() {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderByIdDTO>();
        }
    }
}
