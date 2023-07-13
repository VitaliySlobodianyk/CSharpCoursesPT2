using Common.Interfaces;
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
    public class PizzaRepository : IDataRepository<Pizza>
    {

        private static PizzaRepository? _instance;

        private PizzaRepository()
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

        public static PizzaRepository Init()
        {
            _instance ??= new PizzaRepository();
            return _instance;
        }

        private IList<Pizza> _pizzas;
        public IList<Pizza> Items { get { return _pizzas; } set { } }

        public IList<Pizza> List()
        {
            return Items;
        }

        public Pizza Get(int id)
        {
            return Items.FirstOrDefault(pizza => pizza.Id == id);
        }

        public bool Add(Pizza pizza)
        {
            if (pizza.Name != string.Empty && !Items.Any(p => p.Name.Equals(pizza.Name)))
            {
                Items.Add(new Pizza(pizza.Name)
                {
                    Description = pizza.Description,
                    Diameter = pizza.Diameter,
                    WeightGs = pizza.WeightGs,
                    Ingredients = pizza.Ingredients
                });

                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var pizzaForDelete = Get(id);
            if (pizzaForDelete != null)
            {
                Items.Remove(pizzaForDelete);
                return true;
            }
            return false;
        }

        public bool Update(int id, Pizza pizza)
        {
            var pizzaForUpdate = Get(id);
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

        public IList<Pizza> GetByName(string name, IList<Pizza> pizzas)
        {
            return pizzas.Where(pizza => pizza.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public IList<Pizza> GetByName(string name)
        {
            return Items.Where(pizza => pizza.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
