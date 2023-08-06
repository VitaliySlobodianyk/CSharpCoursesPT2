using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IManagementCars : IDataRepository<Car>
    {
        IList<Car> GetCarsByName(string name);
        IList<Car> GetCarsByName(IList<Car> cars ,string name);
        IList<Car> GetCarsByEnginePower(int power);
        IList<Car> GetCarsByEnginePower(IList<Car> cars, int power);
        IList<Car> GetCarsByEngineVolume(double volume);
        IList<Car> GetCarsByEngineVolume(IList<Car> cars, double volume);
        IList<Car> GetCarsByAge(int age);
        IList<Car> GetCarsByAge(IList<Car> cars, int age);

    }
}   
