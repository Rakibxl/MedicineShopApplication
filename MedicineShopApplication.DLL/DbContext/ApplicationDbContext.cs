using MedicineShopApplication.DLL.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicineShopApplication.DLL.DbContext;

public class ApplicationDbContext :  IdentityDbContext<ApplicationUser,ApplicationRole, int>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }
    
}