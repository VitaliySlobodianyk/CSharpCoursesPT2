using Common.Models;
using Common;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homework1.Controllers
{
    [Route("cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private CarsRepository carsRepository;
        public CarsController() {
            carsRepository = CarsRepository.Init();
        }

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return carsRepository.GetCars();
        }

        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            var searchedCar = carsRepository.GetCar(id);
            return searchedCar == null ? NotFound() : searchedCar;
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Car>> Get([FromQuery] string? producer, [FromQuery] string? model)
        {
            if (producer == null && model == null) {
              return BadRequest("Must specify producer or model query parameters");
            }

            var applicableModels = carsRepository.GetCars();

            if (producer != null)
            {
                applicableModels = carsRepository.GetByProducer(producer, applicableModels);
            }

            if (model != null)
            {
                applicableModels = carsRepository.GetByModel(model, applicableModels);
            }

            return applicableModels.Any() ?  applicableModels.ToList() : NotFound();
        }
    }
}
