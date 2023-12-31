﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.DataManipulation
{
    public interface IListable<T>
    {
        IList<T> List();
        T Get(int id);
    }
}
