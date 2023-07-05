using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class CarsRepository
    {
        private static IList<Car> _cars;
        static CarsRepository()
        {

            _cars = new List<Car>()
            {
              new Car ("Renault", "Megane"){
                 EngineVolume = 1.5,
                 EnginePower= 115,
                 MaxSpeed = 180,
              },
               new Car ("BMW", "335"){
                 EngineVolume = 3.0,
                 EnginePower= 360,
                 MaxSpeed = 280,
              },
               new Car ("Volkswagen", "Passat"){
                 EngineVolume = 2.0,
                 EnginePower= 140,
                 MaxSpeed = 220,
              },
                new Car ("Toyota", "Camry"){
                 EngineVolume = 3.5,
                 EnginePower= 300,
                 MaxSpeed = 200,
              }
            };

        }

        public static IEnumerable<Car> GetCars()
        {
            return _cars;
        }

        public static Car GetCar(int id)
        {
            return _cars.FirstOrDefault(car => car.Id == id);
        }

        public static IEnumerable<Car> GetByProducer(  string producer, IEnumerable<Car> cars)
        {
            return cars.Where(car => car.Producer.ToLower().Contains(producer.ToLower()));
        }

        public static IEnumerable<Car> GetByProducer(string producer)
        {
            return _cars.Where(car => car.Producer.ToLower().Contains(producer.ToLower()));
        }

        public static IEnumerable<Car> GetByModel(string model, IEnumerable<Car> cars)
        {
            return cars.Where(car => car.Model.ToLower().Contains(model.ToLower()));
        }

        public static IEnumerable<Car> GetByModel(string model)
        {
            return _cars.Where(car => car.Model.ToLower().Contains(model.ToLower()));
        }
    }
}
