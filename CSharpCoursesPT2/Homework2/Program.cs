using Common;
using Common.Interfaces;
using Common.Interfaces.Items;
using Common.Models;
using Homework2.Middlewares;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Collections.Generic;

namespace Homework2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddSingleton<IManagementCars, CarsRepository>();

            var app = builder.Build();

            app.UseMiddleware<CarSearchMiddleware>();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.Run();
        }
    }
}