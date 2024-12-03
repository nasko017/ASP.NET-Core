using PhoneFlip.Data.Models;
using PhoneFlip.Data.Repository.Interfaces;
using PhoneFlip.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFlip.Services.Data;

public class TradeService : ITradeService
{
    private readonly IRepository<TradeRequest, Guid> _tradeRepository;
    private readonly IRepository<Ad, Guid> _adRepository;

    public TradeService(IRepository<TradeRequest, Guid> tradeRepository, IRepository<Ad, Guid> adRepository)
    {
        _tradeRepository = tradeRepository;
        _adRepository = adRepository;
    }

    public async Task<IEnumerable<TradeRequest>> GetAllTradesAsync()
    {
        return await _tradeRepository.GetAllAsync();
    }

    public async Task<bool> CreateTradeAsync(TradeRequest tradeRequest)
    {
        // Ensure target ad is not deleted
        var ad = await _adRepository.GetByIdAsync(tradeRequest.TargetAdId);
        if (ad == null || ad.IsDeleted)
        {
            throw new InvalidOperationException("Target ad is unavailable.");
        }

        tradeRequest.IsDeleted = false;
        tradeRequest.Status = "Pending";
        await _tradeRepository.AddAsync(tradeRequest);
        return true;
    }

    public async Task<bool> SoftDeleteTradeAsync(Guid tradeId)
    {
        var trade = await _tradeRepository.GetByIdAsync(tradeId);
        if (trade == null) return false;

        trade.IsDeleted = true;
        return await _tradeRepository.UpdateAsync(trade);
    }

    public async Task<bool> UpdateTradeStatusAsync(Guid tradeId, string status)
    {
        // Validate the trade ID and status
        if (string.IsNullOrWhiteSpace(status) || !new[] { "Pending", "Accepted", "Rejected" }.Contains(status))
        {
            throw new ArgumentException("Invalid trade status.");
        }

        var trade = await _tradeRepository.GetByIdAsync(tradeId);
        if (trade == null)
        {
            return false; // Trade not found
        }

        trade.Status = status;
        _tradeRepository.Update(trade);
        await _tradeRepository.UpdateAsync(trade);

        return true;
    }

    public Task<TradeRequest?> GetTradeByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    //public async Task<bool> SoftDeleteTradeAsync(Guid tradeId)
    //{
    //    var trade = await _tradeRepository.GetByIdAsync(tradeId);
    //    if (trade == null)
    //    {
    //        return false; // Trade not found
    //    }
    //
    //    // Perform a soft delete (if TradeRequest has an IsDeleted property)
    //    trade.Status = "Deleted";;
    //    await _tradeRepository.UpdateAsync(trade);
    //
    //    return true;
    //}
}

