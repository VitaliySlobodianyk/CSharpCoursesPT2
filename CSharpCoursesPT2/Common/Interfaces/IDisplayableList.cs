using Common.Interfaces.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IDisplayableList<T> where T : IDisplayableItem
    {
        string PrintHTML();
        string PrintHTML(IList<T> items);
    }
}
