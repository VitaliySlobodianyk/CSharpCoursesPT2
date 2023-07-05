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
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return CarsRepository.GetCars();
        }

        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            var searchedCar = CarsRepository.GetCar(id);
            return searchedCar == null ? NotFound() : searchedCar;
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Car>> Get([FromQuery] string? producer, [FromQuery] string? model)
        {
            if (producer == null && model == null) {
              return BadRequest("Must specify producer or model query parameters");
            }

            var applicableModels = CarsRepository.GetCars();

            if (producer != null)
            {
                applicableModels = CarsRepository.GetByProducer(producer, applicableModels);
            }

            if (model != null)
            {
                applicableModels = CarsRepository.GetByModel(model, applicableModels);
            }

            return applicableModels.Any() ?  applicableModels.ToList() : NotFound();
        }
    }
}
