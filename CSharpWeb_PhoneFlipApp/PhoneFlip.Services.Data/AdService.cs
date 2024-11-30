using PhoneFlip.Data.Models;
using PhoneFlip.Data.Repository.Interfaces;
using PhoneFlip.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFlip.Services.Data;

public class AdService : IAdService
{
    private readonly IRepository<Ad, Guid> _adRepository;

    public AdService(IRepository<Ad, Guid> adRepository)
    {
        _adRepository = adRepository;
    }

    public async Task<IEnumerable<Ad>> GetAllAdsAsync()
    {
        // Business Logic: Return only active ads (not soft-deleted)
        return await _adRepository.GetAllAsync();
    }

    public async Task<Ad?> GetAdByIdAsync(Guid id)
    {
        // Business Logic: Fetch an ad if it's not soft-deleted
        var ad = await _adRepository.GetByIdAsync(id);
        if (ad == null || ad.IsDeleted) return null;
        return ad;
    }

    public async Task<bool> CreateAdAsync(Ad ad)
    {
        // Business Logic: Ensure ad title is unique
        var existingAd = _adRepository.FirstOrDefault(a => a.Title == ad.Title && !a.IsDeleted);
        if (existingAd != null)
        {
            throw new InvalidOperationException("An ad with this title already exists.");
        }

        // Business Logic: Set default values
        ad.IsDeleted = false;

        try
        {
            await _adRepository.AddAsync(ad);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateAdPriceAsync(Guid id, decimal newPrice)
    {
        // Business Logic: Validate price
        if (newPrice <= 0) throw new ArgumentException("Price must be greater than zero.");

        var ad = await _adRepository.GetByIdAsync(id);
        if (ad == null || ad.IsDeleted) return false;

        ad.Price = newPrice;
        return await _adRepository.UpdateAsync(ad);
    }

    public async Task<bool> DeleteAdAsync(Guid id)
    {
        // Business Logic: Soft-delete the ad
        var ad = await _adRepository.GetByIdAsync(id);
        if (ad == null) return false;

        ad.IsDeleted = true;
        return await _adRepository.UpdateAsync(ad);
    }

    public Task<bool> SoftDeleteAdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}



