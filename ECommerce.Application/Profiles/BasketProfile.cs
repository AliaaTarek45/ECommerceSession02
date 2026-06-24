using AutoMapper;
using ECommerce.Application.DTOs.Baskets;
using ECommerce.Domain.Entities.Baskets;

namespace ECommerce.Application.Profiles
{
    internal class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<CustomerBasket, BasketDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
        }
    }
}
