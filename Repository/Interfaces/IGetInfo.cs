﻿using Repository.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IGetInfo
    {
        public object CountData();
        public object ListEndpoints();
    }
}
