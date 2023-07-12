using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common
{
    public static class PizzaRepository
    {
        private static IList<Pizza> _pizzas;
        static PizzaRepository()
        {
            _pizzas = new List<Pizza>()
            {
                new Pizza ("Pepperoni") {
                Description = "Classic Italian Pizza",
                Diameter= 30,
                WeightGs = 500,
                Ingredients = new List<string> { "Mozarella", "Tomatoes", "Pepperoni", "Black Olives" }
                }
            };
        }

        public static IEnumerable<Pizza> GetPizza()
        {
            return _pizzas;
        }

        public static Pizza GetPizza(int id)
        {
            return _pizzas.FirstOrDefault(pizza => pizza.Id == id);
        }

        public static IEnumerable<Pizza> GetByName(string name, IEnumerable<Pizza> pizzas)
        {
            return pizzas.Where(pizza => pizza.Name.ToLower().Contains(name.ToLower()));
        }

        public static IEnumerable<Pizza> GetByProducer(string name)
        {
            return _pizzas.Where(pizza => pizza.Name.ToLower().Contains(name.ToLower()));
        }

        public static bool UpdatePizza(int id, Pizza pizza)
        {
            var pizzaForUpdate = GetPizza(id);
            if (pizzaForUpdate != null)
            {
                pizzaForUpdate.Name = pizza.Name ?? pizzaForUpdate.Name;
                pizzaForUpdate.Description = pizza.Description ?? pizzaForUpdate.Description;

                if (pizza.Diameter > 0)
                {
                    pizzaForUpdate.Diameter = pizza.Diameter;
                }

                if (pizza.WeightGs > 0)
                {
                    pizzaForUpdate.WeightGs = pizza.WeightGs;
                }

                if (pizza.Ingredients.Count > 0)
                {
                    pizzaForUpdate.Ingredients = pizza.Ingredients;
                }

                return true;
            }
            return false;
        }

        public static void AddPizza(Pizza pizza)
        {
            _pizzas.Add(new Pizza(pizza.Name) {
             Description = pizza.Description,
             Diameter = pizza.Diameter,
             WeightGs = pizza.WeightGs,
             Ingredients = pizza.Ingredients
            });
        }

        public static bool DeletePizza(int id)
        {
            var pizzaForDelete = GetPizza(id);
            if (pizzaForDelete != null)
            {
                _pizzas.Remove(pizzaForDelete);
                return true;
            }
            return false;
        }
    }
}
