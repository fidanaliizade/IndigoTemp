using IndigoTemp.DAL;
using Microsoft.EntityFrameworkCore;
using System;

namespace IndigoTemp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();



            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });
            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "Default",
                     pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            app.UseStaticFiles();


            app.Run();
        }
    }
}
