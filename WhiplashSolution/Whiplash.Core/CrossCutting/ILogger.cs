﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiplash.Core.CrossCutting
{
    public interface ILogger
    {
         void Log(string msg,MessageType messageType);

    }
}
