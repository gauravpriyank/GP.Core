using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Core.Test
{
    public class TestDependency : ITestDependency
    {
        public bool isValid()
        {
            return true;
        }
    }
}
