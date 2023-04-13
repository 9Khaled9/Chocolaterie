using Chocolaterie.DTOs;
using Chocolaterie.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Chocolaterie.Services
{
    public interface IChocolaterieService
    {
        Task<IList<ChocolateBarDto>> ListChocolateBarsByFactoryAsync(int id);
        Task<bool> AddFactoryAsync(FactoryDto dto);
        Task<bool> AddChocolateBarByFactoryAsync(AddChocolateBarByFactoryInfo dto);
        Task<bool> DeleteChocolateBarByFactoryAsync(DeleteChocolateBarByFactoryInfo info);
        Task<StockDto> UpdateStockQuantityAsync(UpdateStockQuantityInfo info);
        Task<bool> AddSaleToWholeSalerAsync(OrderDto dto);
    }
}
