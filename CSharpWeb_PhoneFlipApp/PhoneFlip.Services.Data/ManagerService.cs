
using Microsoft.EntityFrameworkCore;
using PhoneFlip.Data.Models;
using PhoneFlip.Data.Repository.Interfaces;
using PhoneFlip.Services.Data.Interfaces;

namespace PhoneFlip.Services.Data;

public class ManagerService :BaseService, IManagerService
{
    private readonly IRepository<Manager, Guid> managersRepository;

    public ManagerService(IRepository<Manager, Guid> _managersRepository)
    {
        this.managersRepository = _managersRepository;
    }

    public async Task<bool> IsUserManagerAsync(string? userId)
    {
        // Not a valid use-case, but we write defensive programming
        if (String.IsNullOrWhiteSpace(userId))
        {
            return false;
        }

        bool result = await this.managersRepository
            .GetAllAttached()
            .AnyAsync(m => m.UserId.ToString().ToLower() == userId);

        return result;
    }
}
