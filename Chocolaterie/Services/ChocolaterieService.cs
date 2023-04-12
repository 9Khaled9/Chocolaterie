using Chocolaterie.Data;
using AutoMapper;
using Chocolaterie.Entities;
using Microsoft.AspNetCore.Mvc;
using Chocolaterie.DTOs;
using Microsoft.EntityFrameworkCore;
using Chocolaterie.DTOs.Common;

namespace Chocolaterie.Services
{
    public class ChocolaterieService : IChocolaterieService
    {
        private readonly ChocolaterieContext _context;
        private readonly IMapper _mapper;

        public ChocolaterieService(ChocolaterieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Public Methods
        public async Task<IList<ChocolateBarDto>> ListChocolateBarsByFactoryAsync(int id)
        {
            var chocolateBars = await _context.ChocolateBars.Where(c => c.FactoryId == id).ToListAsync();
            var list = _mapper.Map<IList<ChocolateBarDto>>(chocolateBars);

            return list;
        }

        public async Task<bool> AddFactoryAsync(FactoryDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            if (dto.Name is null)
            {
                throw new ArgumentNullException(nameof(dto.Name));
            }

            Factory toAdd = new Factory(dto.Name);
            await _context.Factories.AddAsync(toAdd);
            var rowCount = await _context.SaveChangesAsync();
            return rowCount > 0;
        }

        public async Task<bool> AddChocolateBarByFactoryAsync(AddChocolateBarByFactoryInfo dto)
        {
            var factory = _context.Factories.FindAsync(dto.FactoryId).Result;
            if (factory is null)
            {
                throw new ArgumentNullException(Error.FactoryNotFount);
            }

            CheckChocolateBar(dto.ChocolateBarDto);

            ChocolateBar chocolateBar = new ChocolateBar(dto.ChocolateBarDto.Name, dto.ChocolateBarDto.Price);
            chocolateBar.Description = dto.ChocolateBarDto.Description;

            chocolateBar.Factory = factory;

            await _context.ChocolateBars.AddAsync(chocolateBar);
            var rowCount = await _context.SaveChangesAsync();
            
            return rowCount > 0;
        }

        public async Task<bool> DeleteChocolateBarByFactoryAsync(DeleteChocolateBarByFactoryInfo info)
        {
            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            var factory = await _context.Factories.FindAsync(info.FactoryId);
            if (factory == null)
            {
                throw new ArgumentNullException(Error.FactoryNotFount);
            }

            var chocolateBar = await _context.ChocolateBars.FindAsync(info.ChocolateBarId);
            if (chocolateBar == null)
            {
                throw new ArgumentNullException(Error.ChocolateBarNotFount);
            }

            if(chocolateBar.FactoryId != info.FactoryId)
            {
                throw new ArgumentException(Error.FactoryHasNoRightDeleteOthersChocolateBar);
            }

            _context.ChocolateBars.Remove(chocolateBar);
            var rowCount = await _context.SaveChangesAsync();

            return rowCount > 0;
        }

        #endregion

        #region Private Methods
        private void CheckChocolateBar(ChocolateBarDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentNullException(nameof(dto.Name));
            }
            if (Double.IsNaN(dto.Price) || dto.Price < 0)
            {
                throw new ArgumentException(nameof(dto.Price));
            }
        }

        #endregion
    }
}
