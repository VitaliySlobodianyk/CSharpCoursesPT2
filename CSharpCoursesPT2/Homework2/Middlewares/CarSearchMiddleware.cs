using Common.Models;
using Common;
using Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Homework2.Middlewares
{
    public class CarSearchMiddleware
    {
        private RequestDelegate _request;

        private IManagementCars _cars;

        public CarSearchMiddleware(RequestDelegate request, IManagementCars cars)
        {
            _request = request;
            _cars = cars;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;


            if (request.Path == "/cars")
            {
                IList<Car> carsResult = _cars.List();

                if (request.Query.Keys.Contains("name") && request.Query["name"] != string.Empty)
                {
                    carsResult = _cars.GetCarsByName(carsResult, request.Query["name"]);
                }
                if (request.Query.Keys.Contains("age") && request.Query["age"] != string.Empty)
                {
                    carsResult = _cars.GetCarsByAge(carsResult, int.Parse(request.Query["age"]));
                }
                if (request.Query.Keys.Contains("power") && request.Query["power"] != string.Empty)
                {
                    carsResult = _cars.GetCarsByEnginePower(carsResult, int.Parse(request.Query["power"]));
                }
                if (request.Query.Keys.Contains("volume") && request.Query["volume"] != string.Empty)
                {
                    carsResult = _cars.GetCarsByEngineVolume(carsResult, double.Parse(request.Query["volume"]));
                }

                if (carsResult.Count > 0)
                {
                    response.StatusCode = 200;
                    await response.WriteAsync(_cars.PrintHTML(carsResult));
                }
                else {
                    response.StatusCode = 400;
                    await response.WriteAsync("""
                        <html> 
                        <h1>No Such Cars Found</h1>
                        </html>
                        """);
                }
            }
            else {
                response.StatusCode = 404;
                await response.WriteAsync("""
                 <html> 
                 <h1>404 Page Not Found</h1>
                 </html>
                 """);
                await _request.Invoke(context);
            }

     
        }


    }
}
