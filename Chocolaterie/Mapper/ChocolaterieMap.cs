using AutoMapper;
using Chocolaterie.DTOs;
using Chocolaterie.Models;

namespace Chocolaterie.Mapper
{
    public class ChocolaterieMap : Profile
    {
        public ChocolaterieMap() {
            CreateMap<ChocolateBar, ChocolateBarDto>();
            CreateMap<Client, ClientDto>();
            CreateMap<Discount, DiscountDto>();
            CreateMap<Factory, FactoryDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderLine, OrderLineDto>();
            CreateMap<Stock, StockDto>();
            CreateMap<WholeSaler, WholeSalerDto>();
        }
    }
}
