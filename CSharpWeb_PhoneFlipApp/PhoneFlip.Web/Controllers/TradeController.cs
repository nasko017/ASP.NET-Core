using Microsoft.AspNetCore.Mvc;
using PhoneFlip.Data.Models;
using PhoneFlip.Services.Data.Interfaces;

public class TradeController : Controller
{
    private readonly ITradeService _tradeService;

    public TradeController(ITradeService tradeService)
    {
        _tradeService = tradeService;
    }

    public async Task<IActionResult> Index()
    {
        var trades = await _tradeService.GetAllTradesAsync();
        return View(trades);
    }

    public IActionResult Create(Guid adId)
    {
        return View(new TradeRequest { TargetAdId = adId });
    }

    [HttpPost]
    public async Task<IActionResult> Create(TradeRequest tradeRequest)
    {
        if (!ModelState.IsValid) return View(tradeRequest);

        await _tradeService.CreateTradeAsync(tradeRequest);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        await _tradeService.SoftDeleteTradeAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
