using PhoneFlip.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFlip.Services.Data.Interfaces;

public interface ITradeService
{
    Task<IEnumerable<TradeRequest>> GetAllTradesAsync();
    Task<TradeRequest?> GetTradeByIdAsync(Guid id);
    Task<bool> CreateTradeAsync(TradeRequest tradeRequest);
    Task<bool> UpdateTradeStatusAsync(Guid tradeId, string status);
    Task<bool> SoftDeleteTradeAsync(Guid tradeId);

}
