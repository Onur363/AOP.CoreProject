﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class DataBaseLogger : LoggerServiceBase
    {
        public DataBaseLogger() : base("DatabaseLogger")
        {
        }
    }
}
