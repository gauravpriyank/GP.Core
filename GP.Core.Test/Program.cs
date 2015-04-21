using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using GP.Core.ExceptionHandling;
using GP.Core.Logging;
using System;

namespace GP.Core.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Configure();
            //Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write("teat");


            try
            {
                throw new ArgumentNullException("testing");
                //Logger.LogError(new Exception("test"));
                //var rethrow = ExceptionManager.HandleException(new Exception("test ex"), "UIPolicy");

                //var value = ServiceLocator.Current.GetInstance<TestClass>().DependencyTest();

                //Console.WriteLine(value);

            }
            catch (Exception ex)
            {

                // IConfigurationSource config = ConfigurationSourceFactory.Create();
                //ExceptionPolicyFactory policyFactory = new ExceptionPolicyFactory(config);
                //Microsoft.Practices.EnterpriseLibrary.Logging.Logger.SetLogWriter(new LogWriterFactory().Create());
                //var _entLibExceptionManager = policyFactory.CreateManager();

                var rethrow = GP.Core.ExceptionHandling.ExceptionManager.HandleException(ex, "UIPolicy");

                //if (rethrow)
                //{
                //    throw;
                //}

                //Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write("teat");
                
            }

            Console.ReadLine();
        }

        public static void Configure()
        {
            var unitycontainer = new UnityContainer();
            
            unitycontainer.RegisterType<IExceptionManager, GP.Core.ExceptionHandling.EntLib.ExceptionManager>();
            unitycontainer.RegisterType<ILogger, GP.Core.Logging.EntLib.Logger>();
            unitycontainer.RegisterType<ITestDependency,TestDependency>();
            
            //var configurator = new UnityContainerConfigurator(unitycontainer);
            
            //EnterpriseLibraryContainer.ConfigureContainer(configurator,
            //               ConfigurationSourceFactory.Create());
            //unitycontainer.LoadConfiguration()           

            IServiceLocator serviceLocator = new UnityServiceLocator(unitycontainer);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
            
        }       

    }
}
