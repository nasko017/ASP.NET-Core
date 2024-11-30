using Microsoft.AspNetCore.Mvc;
using PhoneFlip.Data.Models;
using PhoneFlip.Services.Data.Interfaces;
using PhoneFlip.Web.Infrastructure.Extensions;


namespace PhoneFlip.Web.Controllers;

public class BaseController : Controller
{
    protected readonly IManagerService managerService;

    public BaseController(IManagerService _managerService)
    {
        this.managerService = _managerService;
    }

    protected bool IsGuidValid(string? id, ref Guid parsedGuid)
    {
        // Non-existing parameter in the URL
        if (String.IsNullOrWhiteSpace(id))
        {
            return false;
        }

        // Invalid parameter in the URL
        bool isGuidValid = Guid.TryParse(id, out parsedGuid);
        if (!isGuidValid)
        {
            return false;
        }

        return true;
    }

    protected async Task<bool> IsUserManagerAsync()
    {
        string? userId = this.User.GetUserId();
        bool isManager = await this.managerService
            .IsUserManagerAsync(userId);

        return isManager;
    }

    protected async Task AppendUserCookieAsync()
    {
        bool isManager = await this.IsUserManagerAsync();

        this.HttpContext.Response.Cookies.Append("IsManager", isManager.ToString());
    }
}
