using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotalMVC.Logging
{
    public interface ILogger
    {
        void Information(string message);
        void Information(string fmt, params object[] vars);

    }
}