﻿using Chocolaterie.Data;
using Chocolaterie.DTOs;
using Chocolaterie.Entities;
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

        [HttpPost("AddFactory")]
        public async Task<IActionResult> AddFactoryAsync(FactoryDto dto)
        {
            var result = await _chocolaterieService.AddFactoryAsync(dto);

            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("ListChocolateBarsByFactory/{id}")]
        public async Task<IList<ChocolateBarDto>> ListChocolateBarsByFactoryAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var list = await _chocolaterieService.ListChocolateBarsByFactoryAsync(id);

            return list;
        }

        [HttpPost("AddChocolateBarByFactory")]
        public async Task<IActionResult> AddChocolateBarByFactoryAsync(AddChocolateBarByFactoryInfo info)
        {
            var result = await _chocolaterieService.AddChocolateBarByFactoryAsync(info);

            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("DeleteChocolateBarByFactory")]
        public async Task<IActionResult> DeleteChocolateBarByFactoryAsync(DeleteChocolateBarByFactoryInfo info)
        {
            var result = await _chocolaterieService.DeleteChocolateBarByFactoryAsync(info);

            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("UpdateStockQuantity")]
        public async Task<ActionResult<StockDto>> UpdateStockQuantityAsync(UpdateStockQuantityInfo info)
        {
            var result = await _chocolaterieService.UpdateStockQuantityAsync(info);

            return Ok(result);


        }

        [HttpPost("AddSaleToWholeSaler")]
        public async Task<IActionResult> AddSaleToWholeSalerAsync(OrderDto dto)
        {
            var result = await _chocolaterieService.AddSalesOrderToWholeSalerAsync(dto);

            if (result is null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("RequestQuote")]
        public async Task<OrderDto> RequestQuote(OrderDto dto)
        {
            var result = await _chocolaterieService.RequestQuote(dto);

            return result;
        }
    }
}
