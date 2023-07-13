using Common.Interfaces.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Car  : ICountable
    {
        public int Id { get; set; }
        public string? Producer { get; set; }
        public string? Model { get; set; }
        public double EngineVolume { get; set; }
        public int EnginePower { get; set; }
        public int MaxSpeed { get; set; }

        public static int Counter { get; private set; } = 0;

        public Car(string producer, string model)
        {
            Id = ++Counter;
            Producer = producer;
            Model = model;
        }

    }
}
