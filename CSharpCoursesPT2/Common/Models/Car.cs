using Common.Interfaces.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Car : ICountable, IDisplayableItem
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public double? EngineVolume { get; set; }
        public int? EnginePower { get; set; }
        public int? MaxSpeed { get; set; }

        public DateTime ProductionDate { get; set; }

        public Car(string producer, string model, string vin) :this(producer, model)
        {
            VIN = vin;
        }
        public Car(string producer, string model)
        {
            Producer = producer;
            Model = model;
        }

        public int GetAgeInYears()
        {
            return (int)Math.Floor((DateTime.Now - ProductionDate).TotalDays / 365.245);
        }

        public override string ToString()
        {
            var resultString = $"""
                Producer: {Producer}
                Model: {Model}
                Engine Volume: {EngineVolume} litre
                Engine Power: {EnginePower} hp
                Max speed: {MaxSpeed} km/h
                """;
            if (!ProductionDate.Equals(new DateTime()))
            {
                resultString += $"Date produced {ProductionDate.ToShortDateString()} ({GetAgeInYears()} years)";
            }

            return resultString;
        }

        public string PrintHTML()
        {
            var resultString = $"""
                <p> Producer: {Producer} </p>
                <p> Model: {Model} </p>
                <p> Engine Volume: {EngineVolume} <i>litre</i></p>
                <p> Engine Power: {EnginePower} <i>hp</i></p>
                <p> Max speed: {MaxSpeed} <i>km/h</i></p>
                """;
            if (!ProductionDate.Equals(new DateTime()))
            {
                resultString += $"<p>Date produced {ProductionDate.ToShortDateString()} ({GetAgeInYears()} years)</p>";
            }

            return resultString;
        }
    }
}
