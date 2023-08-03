using Common.Interfaces;
using Common.Interfaces.Items;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CarsRepository : IManagementCars
    {
        private IList<Car> _cars;

        public IList<Car> Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public CarsRepository(List<Car> cars)
        {
            _cars = new List<Car>(cars);
        }

        public IEnumerable<Car> GetByProducer(string producer, IEnumerable<Car> cars)
        {
            return cars.Where(car => car.Producer.ToLower().Contains(producer.ToLower()));
        }

        public IEnumerable<Car> GetByProducer(string producer)
        {
            return _cars.Where(car => car.Producer.ToLower().Contains(producer.ToLower()));
        }

        public IEnumerable<Car> GetByModel(string model, IEnumerable<Car> cars)
        {
            return cars.Where(car => car.Model.ToLower().Contains(model.ToLower()));
        }

        public IEnumerable<Car> GetByModel(string model)
        {
            return _cars.Where(car => car.Model.ToLower().Contains(model.ToLower()));
        }

        public IList<Car> GetCarsByName(string name)
        {
            return GetCarsByName(_cars, name);
        }

        public IList<Car> GetCarsByEnginePower(int power)
        {
            return GetCarsByEnginePower(_cars, power);
        }

        public IList<Car> GetCarsByEngineVolume(double volume)
        {
            return GetCarsByEngineVolume(_cars, volume);
        }

        public IList<Car> GetCarsByAge(int age)
        {
            return GetCarsByAge(_cars, age);
        }

        public IList<Car> GetCarsByName(IList<Car> cars, string name)
        {
            return cars.Where(car => car.Producer.ToLower().Contains(name.ToLower()) || car.Model.ToLower().Contains(name.ToLower())).ToList();
        }

        public IList<Car> GetCarsByEnginePower(IList<Car> cars, int power)
        {
            return cars.Where(car => car.EnginePower >= power).ToList();
        }

        public IList<Car> GetCarsByEngineVolume(IList<Car> cars, double volume)
        {
            return cars.Where(car => car.EngineVolume >= volume).ToList();
        }

        public IList<Car> GetCarsByAge(IList<Car> cars, int age)
        {
            return cars.Where(car => car.GetAgeInYears() <= age).ToList();
        }

        public string PrintHTML()
        {
            return PrintHTML(_cars);
        }

        public string PrintHTML(IList<Car> items)
        {
            var res = "<html><ul>";

            foreach (IDisplayableItem car in items)
            {
                res += "<li>" + car.PrintHTML() + "</li>";
            }

            return res + "</ul></html>";
        }

        public IList<Car> List()
        {
            return _cars;
        }

        public Car Get(int id)
        {
            return _cars.FirstOrDefault(car => car.Id == id);
        }

        public bool Add(Car item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Car item)
        {
            throw new NotImplementedException();
        }
    }
}
