using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MvcCastleIntegration.Dependencies;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace MvcCastleIntegration.Infrastructure
{
    public class ApplicationCastleInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Register working dependencies
            container.Register(Component.For<IMessageSource>().ImplementedBy<HelloWorldMessageSource>().LifestylePerWebRequest());

            // Register the MVC controllers one by one
            // container.Register(Component.For<TestController>().LifestylePerWebRequest());

            // Register all the MVC controllers in the current executing assembly
            var contollers = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(Controller)).ToList();
            foreach (var controller in contollers)
            {
                container.Register(Component.For(controller).LifestylePerWebRequest());
            }
        }
    }
}