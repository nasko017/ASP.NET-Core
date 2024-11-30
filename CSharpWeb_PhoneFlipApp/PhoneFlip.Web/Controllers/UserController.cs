using Microsoft.AspNetCore.Mvc;
using PhoneFlip.Services.Data.Interfaces;

namespace PhoneFlip.Web.Controllers;

public class UserController:Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userService.GetAllUsersAsync();
        return View(users);
    }

    public async Task<IActionResult> AssignRole(Guid userId, string role)
    {
        var success = await _userService.AssignUserToRoleAsync(userId, role);
        return RedirectToAction(nameof(Index));
    }
}
