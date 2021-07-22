using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recapture.Common
{
    public enum LogLevel
    {
        All = 0,
        Trace = 1,
        Debug = 2,
        Info = 3,
        Warn = 4,
        Error = 5,
        Fatal = 6,
        /// <summary>
        /// Do not log anything.
        /// </summary>
        Off = 7,
    }
}