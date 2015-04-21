using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Core.Test
{
    public class TestClass
    {
        private ITestDependency _dependency;

        public TestClass(ITestDependency dependency)
        {
            _dependency = dependency;
        }

        public bool DependencyTest()
        {
            return _dependency.isValid();
        }
    }
}
