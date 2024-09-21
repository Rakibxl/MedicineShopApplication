using Microsoft.AspNetCore.Identity;

namespace MedicineShopApplication.DLL.Model;

public class ApplicationUser : IdentityUser<int>
{
    public string Email { get; set; }
    public string PassWord { get; set; }
}