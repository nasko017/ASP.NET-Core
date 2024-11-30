using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhoneFlip.Data;
using PhoneFlip.Data.Models;
using PhoneFlip.Data.Repository.Interfaces;
using PhoneFlip.Data.Repository;
using PhoneFlip.Services.Data.Interfaces;
using PhoneFlip.Services.Data;

namespace PhoneFlip.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<PhoneFlipDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<PhoneFlipDbContext>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IRepository<Ad, Guid>, BaseRepository<Ad, Guid>>();
            builder.Services.AddScoped<IRepository<TradeRequest, Guid>, BaseRepository<TradeRequest, Guid>>();
            builder.Services.AddScoped<IAdService, AdService>();
            builder.Services.AddScoped<ITradeService, TradeService>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
