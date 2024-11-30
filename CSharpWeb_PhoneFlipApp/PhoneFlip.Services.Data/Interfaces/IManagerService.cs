

namespace PhoneFlip.Services.Data.Interfaces;


public interface IManagerService
{
    Task<bool> IsUserManagerAsync(string? userId);
}
 