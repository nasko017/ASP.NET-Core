using Microsoft.AspNetCore.Mvc;
using PhoneFlip.Data.Models;
using PhoneFlip.Data.Repository.Interfaces;
using PhoneFlip.Services.Data;
using PhoneFlip.Services.Data.Interfaces;

namespace PhoneFlip.Web.Controllers;

public class AdController : Controller
{
    private readonly IAdService _adService;

    public AdController(IAdService adService)
    {
        _adService = adService;
    }

    public async Task<IActionResult> Index()
    {
        var ads = await _adService.GetAllAdsAsync();
        return View(ads);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Ad ad)
    {
        if (ModelState.IsValid)
        {
            var success = await _adService.CreateAdAsync(ad);
            if (success) return RedirectToAction(nameof(Index));
        }
        return View(ad);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var ad = await _adService.GetAdByIdAsync(id);
        if (ad == null) return NotFound();
        return View(ad);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _adService.SoftDeleteAdAsync (id);
        if (success) return RedirectToAction(nameof(Index));
        return NotFound();
    }
}
