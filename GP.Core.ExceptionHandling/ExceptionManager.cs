using System;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using EntLibExceptionManager = Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionManager;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace GP.Core.ExceptionHandling.EntLib
{
    public class ExceptionManager : IExceptionManager
    {
        private readonly static EntLibExceptionManager _entLibExceptionManager;
        
        static ExceptionManager()
        {
            IConfigurationSource config = ConfigurationSourceFactory.Create();
            ExceptionPolicyFactory policyFactory = new ExceptionPolicyFactory(config);
            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.SetLogWriter(new LogWriterFactory().Create());
            _entLibExceptionManager = policyFactory.CreateManager();
        }

        public bool HandleException(Exception exceptionToHandle, string policyName)
        {
            return _entLibExceptionManager.HandleException(exceptionToHandle, policyName);
        }

        public bool HandleException(Exception exceptionToHandle, string policyName, out Exception exceptionToThrow)
        {
            return _entLibExceptionManager.HandleException(exceptionToHandle, policyName, out exceptionToThrow);
        }
    }
}
