using Chocolaterie.Data;
using Chocolaterie.DTOs;
using Chocolaterie.Models;
using Chocolaterie.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chocolaterie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChocolaterieController : ControllerBase
    {
        private readonly IChocolaterieService _chocolaterieService;

        public ChocolaterieController(IChocolaterieService chocolaterieService)
        {
            _chocolaterieService = chocolaterieService;
        }

        [HttpGet("GetChocolateBarsListByFactoryAsync/{id}")]
        public async Task<IList<ChocolateBarDto>> GetChocolateBarsListByFactoryAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var list = await _chocolaterieService.GetChocolateBarsListByFactoryAsync(id);

            return list;
        }

        [HttpPost("AddFactoryAsync")]
        public async Task<ActionResult> AddFactoryAsync(FactoryDto dto)
        {
            var result = await _chocolaterieService.AddFactoryAsync(dto);

            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost("AddFactoryAsync")]
        public async Task<ActionResult> AddChocolateBarByFactoryAsync(AddChocolateBarByFactoryInfo dto)
        {
            var result = await _chocolaterieService.AddChocolateBarByFactoryAsync(dto);

            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
