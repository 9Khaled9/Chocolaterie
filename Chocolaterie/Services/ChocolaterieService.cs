using Chocolaterie.Data;
using AutoMapper;
using Chocolaterie.Entities;
using Microsoft.AspNetCore.Mvc;
using Chocolaterie.DTOs;
using Microsoft.EntityFrameworkCore;
using Chocolaterie.DTOs.Common;
using Chocolaterie.Entities.Common;

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

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                throw new ArgumentNullException(Error.OrderNotFound);
            }

            _context.Orders.Remove(order);
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

            if (chocolateBar.FactoryId != info.FactoryId)
            {
                throw new ArgumentException(Error.FactoryHasNoRightAccessNotOwnedChocolateBar);
            }

            _context.ChocolateBars.Remove(chocolateBar);
            var rowCount = await _context.SaveChangesAsync();

            return rowCount > 0;
        }

        public async Task<StockDto> UpdateStockQuantityAsync(UpdateStockQuantityInfo info)
        {
            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            var wholeSaler = await _context.WholeSalers.FindAsync(info.WholeSalerId);
            if (wholeSaler == null)
            {
                throw new ArgumentNullException(Error.WholeSalerNotFount);
            }

            //var stock = await _context.Stocks.FindAsync(info.StockId);
            var stock = _context.Stocks.Where(s => s.Id == info.StockId).Include(s => s.WholeSaler).FirstOrDefault();
            if (stock == null)
            {
                throw new ArgumentNullException(Error.StockNotFount);
            }

            if (info.WholeSalerId != stock.WholeSaler.Id)
            {
                throw new ArgumentNullException(Error.WholeSalerHasNoRightAccessNotOwnedChocolateBar);
            }

            _context.Entry(stock).State = EntityState.Modified;

            try
            {
                stock.Quatity = info.Quantity;
                await _context.SaveChangesAsync();

                var stockDto = _mapper.Map<StockDto>(stock);
                return stockDto;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(info.StockId))
                {
                    throw new ArgumentNullException(Error.StockNotFount);
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<OrderDto> AddSalesOrderToWholeSalerAsync(OrderDto dto) => await AddSaleToWholeSalerAsync(dto, OrderType.SalesOrder);
        public async Task<OrderDto> RequestQuote(OrderDto dto) => await AddSaleToWholeSalerAsync(dto, OrderType.Quotation);

        public async Task<OrderDto> AddSaleToWholeSalerAsync(OrderDto dto, OrderType orderType)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            CheckOrder(dto);

            try
            {
                var total = 0.0;
                ChocolateBar chocolateBar = null;
                Stock stock = null;

                var orderLines = new List<OrderLine>();
                foreach (var lineDto in dto.OrderLines)
                {
                    orderLines.Add(new OrderLine
                    {
                        Quantity = lineDto.Quantity,
                        StockId = lineDto.StockId
                    });
                    stock = _context.Stocks.FindAsync(lineDto.StockId).Result;
                    if (orderType == OrderType.SalesOrder)
                    {
                        stock.Quatity -= lineDto.Quantity;
                    }
                    chocolateBar = _context.ChocolateBars.FindAsync(stock.ChocolateBarId).Result;
                    total += chocolateBar.Price;
                }

                var order = new Order
                {
                    OrderType = orderType,
                    Description = dto.Description,
                    WholeSalerId = dto.WholeSalerId,
                    ClientId = dto.ClientId,
                    Total = total
                };

                order.OrderLines = orderLines;
                ApplyOrderDiscount(order);

                await _context.Orders.AddAsync(order);
                var rowCount = await _context.SaveChangesAsync();

                var result = _mapper.Map<OrderDto>(order);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods
        private void ApplyOrderDiscount(Order order)
        {
            var chocolateBarsCount = order.OrderLines.Sum(d => d.Quantity);
            var discount = _context.Discounts.Where(d => d.AboveConstraint < chocolateBarsCount).OrderByDescending(d => d.AboveConstraint).FirstOrDefault();
            if (discount != null)
            {
                order.DiscountAmount = discount.Percentage * order.Total / 100;
                order.TotalAfterDiscount = order.Total - order.DiscountAmount;
                order.DiscountId = discount.Id;
            }
        }

        private void CheckOrder(OrderDto dto)
        {
            if (!WholeSalerExists(dto.WholeSalerId))
            {
                throw new ArgumentNullException(Error.ChocolateBarMustBeSoldByWholeSaler);
            }
            if (!ClientExists(dto.ClientId))
            {
                throw new ArgumentNullException(Error.ClientMustExist);
            }

            CheckOrderLines(dto.OrderLines);
        }

        private void CheckOrderLines(IList<OrderLineDto> orderLinesDto)
        {
            if (orderLinesDto is null || orderLinesDto.Count < 1)
            {
                throw new ArgumentException(Error.OrderCannotBeEmpty);
            }

            foreach (var line in orderLinesDto)
            {
                var stock = _context.Stocks?.FindAsync(line.StockId).Result;

                if (stock is null)
                {
                    throw new ArgumentException(Error.StockNotFount + ": (" + line.StockId + ")");
                }
                if (line.Quantity < 1)
                {
                    throw new ArgumentException(Error.LineQuantityCannotBeTessThen1);
                }
                if (line.Quantity > stock.Quatity)
                {
                    throw new ArgumentException(Error.ChocolateBarNumberCannotBeGreaterThanStock);
                }
            }

            if (orderLinesDto.GroupBy(l => l.StockId).Where(c => c.Count() > 1).Any())
            {
                throw new ArgumentException(Error.CantBeDuplicatesInOrder);
            }
        }

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

        private bool ChocolateBarExists(int id)
        {
            return (_context.ChocolateBars?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private bool WholeSalerExists(int id)
        {
            return (_context.WholeSalers?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private bool ClientExists(int id)
        {
            return (_context.Clients?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private bool StockExists(int id)
        {
            return (_context.Stocks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        #endregion
    }
}
