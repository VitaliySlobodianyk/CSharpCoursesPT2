using Common;
using Common.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homework1_Additional.Controllers
{
    [Route("pizza")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        // GET: api/<PizzaController>
        [HttpGet]
        public IEnumerable<Pizza> Get()
        {
            return PizzaRepository.GetPizza();
        }

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var searchedCar = PizzaRepository.GetPizza(id);
            return searchedCar == null ? NotFound() : searchedCar;
        }

        // POST api/<PizzaController>
        [HttpPost]
        public ActionResult Post([FromBody] Pizza pizza)
        {
            PizzaRepository.AddPizza(pizza);
            return Ok(); 
        }

        // PUT api/<PizzaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pizza pizza)
        {
           var success =  PizzaRepository.UpdatePizza(id, pizza);
            if (success) {
            return Ok();
            }
            return NotFound();
        }

        // DELETE api/<PizzaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var success = PizzaRepository.DeletePizza(id);
            if (success)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
