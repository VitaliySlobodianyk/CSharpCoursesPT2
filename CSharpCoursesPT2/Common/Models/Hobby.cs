using Common.Interfaces.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Hobby : ICountable, IDisplayableItem
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Experience { get; set; }
        public string Level { get; set; }

        public Hobby(string name, double experience)
        {
            Name = name;
            Experience = experience;
        }

        public string PrintHTML()
        {
            return $"""
                <div>
                <p> Hobby: {Name}.</p>
                <p> Experience: {Experience} years.</p>
                <p> Experience Level: {Level}.</p>
                </div>
                """;
        }
    }
}
