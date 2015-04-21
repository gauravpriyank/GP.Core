using System;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.ServiceLocation;

namespace GP.Core.ExceptionHandling
{
    public static class ExceptionManager
    {
        private static readonly IExceptionManager _exceptionManager;

        static ExceptionManager()
        {
            
            _exceptionManager = ServiceLocator.Current.GetInstance<IExceptionManager>();
        }

        public static bool HandleException(Exception exceptionToHandle, string policyName)
        {
            return _exceptionManager.HandleException(exceptionToHandle, policyName);
        }

        public static bool HandleException(Exception exceptionToHandle, string policyName, out Exception exceptionToThrow)
        {
            return _exceptionManager.HandleException(exceptionToHandle, policyName, out exceptionToThrow);
        }
    }
}
