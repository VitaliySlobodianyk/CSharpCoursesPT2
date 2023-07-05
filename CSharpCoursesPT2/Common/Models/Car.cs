using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Car
    {
        public int Id { get; private set; }
        public string? Producer { get; set; }
        public string? Model { get; set; }
        public double EngineVolume { get; set; }
        public int EnginePower { get; set; }
        public int MaxSpeed { get; set; }

        private static int Counter;

        static Car()
        {
            Counter = 0;
        }
        public Car(string producer, string model)
        {
            Id = ++Counter;
            Producer = producer;
            Model = model;
        }

    }
}
