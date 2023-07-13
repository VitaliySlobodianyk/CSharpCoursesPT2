using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.DataManipulation
{
    public interface IUpdatable<T>
    {
        IList<T> Items { get; set; }
        bool Update(int id, T item);
    }
}
