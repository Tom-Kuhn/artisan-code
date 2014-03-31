using Castle.Windsor;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcCastleIntegration.Infrastructure
{
    public class CastleControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        public IWindsorContainer Container { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CastleControllerFactory"/> class.
        /// </summary>
        /// <param name="container">The container used to resolve the MVC controllers.</param>
        /// <exception cref="System.ArgumentNullException">container</exception>
        public CastleControllerFactory(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.Container = container;
        }

        /// <summary>
        /// Retrieves the controller instance for the specified request context and controller type.
        /// </summary>
        /// <param name="requestContext">The context of the HTTP request, which includes the HTTP context and route data.</param>
        /// <param name="controllerType">The type of the controller.</param>
        /// <returns>
        /// The controller instance.
        /// </returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }

            // Retrieve the requested controller from Castle
            return Container.Resolve(controllerType) as IController;
        }

        /// <summary>
        /// Releases the specified controller.
        /// </summary>
        /// <param name="controller">The controller to release.</param>
        public override void ReleaseController(IController controller)
        {
            // If controller implements IDisposable, clean it up responsibly
            var disposableController = controller as IDisposable;
            if (disposableController != null)
            {
                disposableController.Dispose();
            }

            // Inform Castle that the controller is no longer required
            Container.Release(controller);
        }
    }
}