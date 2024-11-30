using PhoneFlip.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFlip.Services.Data.Interfaces;

public interface IAdService
{
    Task<IEnumerable<Ad>> GetAllAdsAsync();
    Task<Ad?> GetAdByIdAsync(Guid id);
    Task<bool> CreateAdAsync(Ad ad);
    Task<bool> SoftDeleteAdAsync(Guid id);
    Task<bool> UpdateAdPriceAsync(Guid id, decimal newPrice);
}
