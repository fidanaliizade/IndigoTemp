using IndigoTemp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IndigoTemp.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Products {  get; set; }  
     
    }
}
