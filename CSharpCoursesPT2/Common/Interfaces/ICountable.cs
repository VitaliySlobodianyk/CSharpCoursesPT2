using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ICountable
    {
        int Id { get; set; }
        static int Counter { get; private set; } 
    }
}
