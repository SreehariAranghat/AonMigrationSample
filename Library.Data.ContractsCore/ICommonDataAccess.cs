﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Contracts
{
    public interface ICommonDataAccess
    {
        bool Exist(string key);
    }
}
