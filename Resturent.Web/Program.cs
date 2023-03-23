using Microsoft.AspNetCore.Cors.Infrastructure;
using Resturent.Web.Services.IServices;
using Resturent.Web.Services;
using Resturent.Web.Models;

namespace Resturent.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpClient<IProductService, ProductService>();

            //services.AddHttpClient<ICartService, CartService>();
            //services.AddHttpClient<ICouponService, CouponService>();

            ServiceUrls serviceUrls = builder.Configuration.GetSection("ServiceUrls").Get<ServiceUrls>();
            ServiceConstant.ProductApiBase = serviceUrls.ProductApi;

            //SD.ShoppingCartAPIBase = Configuration["ServiceUrls:ShoppingCartAPI"];
            //SD.CouponAPIBase = Configuration["ServiceUrls:CouponAPI"];

            builder.Services.AddScoped<IProductService, ProductService>();

            //services.AddScoped<ICartService, CartService>();
            //services.AddScoped<ICouponService, CouponService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}