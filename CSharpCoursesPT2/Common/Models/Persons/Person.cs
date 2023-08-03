using Common.Interfaces.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Persons
{
    public class Person : ICountable, IDisplayableItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public static int Counter { get; private set; } = 0;
        public Person(string name)
        {
            Name = name;
        }

        public string PrintHTML()
        {
            return $""" 
            <p>Name: {Name}</p>
            """;
        }
    }
}
