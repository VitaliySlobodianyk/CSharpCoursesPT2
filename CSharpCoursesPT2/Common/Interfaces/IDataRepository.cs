using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces.DataManipulation;

namespace Common.Interfaces
{
    public interface IDataRepository<T> : IListable<T>, IAddable<T>, IDeletable<T>, IUpdatable<T>
    {
    }
}
