using System;

namespace GP.Core.ExceptionHandling
{
    public interface IExceptionManager
    {
        bool HandleException(Exception exceptionToHandle, string policyName);

        bool HandleException(Exception exceptionToHandle, string policyName, out Exception exceptionToThrow);
    }
}
