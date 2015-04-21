using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GP.Logger
{
    public interface ILogger
    {
        void Log(Exception ex, string customMessage);
        void Log(string customMessage);
    }
}
