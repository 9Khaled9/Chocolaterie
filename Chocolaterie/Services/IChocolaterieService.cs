using Chocolaterie.DTOs;
using Chocolaterie.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chocolaterie.Services
{
    public interface IChocolaterieService
    {
        Task<IList<ChocolateBarDto>> GetChocolateBarsListByFactoryAsync(int id);
        Task<bool> AddFactoryAsync(FactoryDto dto);
        Task<bool> AddChocolateBarByFactoryAsync(AddChocolateBarByFactoryInfo dto);
    }
}
