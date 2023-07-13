using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.DataManipulation
{
    public interface IAddable<T>
    {
        IList<T> Items { get; set; }
        bool Add(T item);
    }
}
