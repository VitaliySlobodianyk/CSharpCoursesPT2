using Common.Models;
using Common;

namespace Homework2.Middlewares
{
    public class CarSearchManager
    {
        private RequestDelegate _request;

        private CarsRepository _carsRepository;

        public CarSearchManager(RequestDelegate request)
        {
            _request = request;
            _carsRepository = CarsRepository.Init();

        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;


            if (request.Path == "/cars")
            {
                IList<Car> carsResult = _carsRepository.GetCars().ToList();

                if (request.Query.Keys.Contains("name") && request.Query["name"] != string.Empty)
                {
                    carsResult = _carsRepository.GetCarsByName(carsResult, request.Query["name"]);
                }
                if (request.Query.Keys.Contains("age") && request.Query["age"] != string.Empty)
                {
                    carsResult = _carsRepository.GetCarsByAge(carsResult, int.Parse(request.Query["age"]));
                }
                if (request.Query.Keys.Contains("power") && request.Query["power"] != string.Empty)
                {
                    carsResult = _carsRepository.GetCarsByEnginePower(carsResult, int.Parse(request.Query["power"]));
                }
                if (request.Query.Keys.Contains("volume") && request.Query["volume"] != string.Empty)
                {
                    carsResult = _carsRepository.GetCarsByEngineVolume(carsResult, double.Parse(request.Query["volume"]));
                }

                await response.WriteAsync(_carsRepository.PrintHTML(carsResult));
            }
            else {
                await response.WriteAsync("""
                 <html> 
                 <h1>404 Page Not Found</h1>
                 </html>
                 """);
            }

            await _request.Invoke(context);
        }


    }
}
