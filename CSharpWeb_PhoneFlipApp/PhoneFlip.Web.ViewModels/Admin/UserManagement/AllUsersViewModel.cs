using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFlip.Web.ViewModels.Admin.UserManagement;

public class AllUsersViewModel
{
    public string Id { get; set; } = null!;

    public string? Email { get; set; }

    public IEnumerable<string> Roles { get; set; } = null!;
}
