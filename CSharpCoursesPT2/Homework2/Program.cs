using Common;
using Common.Interfaces.Items;
using Common.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Collections.Generic;

namespace Homework2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var carsReposity = CarsRepository.Init();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

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

            app.Run(async context =>
            {
                var request = context.Request;
                var response = context.Response;


                if (request.Path == "/cars")
                {
                    IList<Car> carsResult = carsReposity.GetCars().ToList();

                    if (request.Query.Keys.Contains("name") && request.Query["name"] != string.Empty)
                    {
                        carsResult = carsReposity.GetCarsByName(carsResult, request.Query["name"]);
                    }
                    if (request.Query.Keys.Contains("age") && request.Query["age"] != string.Empty)
                    {
                        carsResult = carsReposity.GetCarsByAge(carsResult, int.Parse(request.Query["age"]));
                    }
                    if (request.Query.Keys.Contains("power") && request.Query["power"] != string.Empty)
                    {
                        carsResult = carsReposity.GetCarsByEnginePower(carsResult, int.Parse(request.Query["power"]));
                    }
                    if (request.Query.Keys.Contains("volume") && request.Query["volume"] != string.Empty)
                    {
                        carsResult = carsReposity.GetCarsByEngineVolume(carsResult, double.Parse(request.Query["volume"]));
                    }

                  
                    await response.WriteAsync(carsReposity.PrintHTML(carsResult));
                }
            });

            //  app.MapRazorPages();

            app.Run();
        }
    }
}