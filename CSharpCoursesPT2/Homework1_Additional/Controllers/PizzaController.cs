using Common;
using Common.Interfaces;
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
        private PizzaRepository _pizzaRepository;
        public PizzaController()
        {
            _pizzaRepository = PizzaRepository.Init();
        }

        // GET pizza
        [HttpGet]
        public IEnumerable<Pizza> Get()
        {
            return _pizzaRepository.List();
        }

        // GET pizza/5
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var searchedPizza = _pizzaRepository.Get(id);
            return searchedPizza == null ? NotFound() : searchedPizza;
        }

        // POST pizza
        [HttpPost]
        public ActionResult Post([FromBody] Pizza pizza)
        {
           var success = _pizzaRepository.Add(pizza);
            if (success)
            {
                return Ok();
            }
            return Conflict("Pizza with such name is already in the menu! \n Consider update operation!");
        }

        // PUT pizza/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pizza pizza)
        {
            var success = _pizzaRepository.Update(id, pizza);
            if (success)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE pizza/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var success = _pizzaRepository.Delete(id);
            if (success)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
