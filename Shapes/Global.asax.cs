using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Shapes.Services;
using Ninject;
using Ninject.Syntax;

namespace Shapes
{
   public class MvcApplication : System.Web.HttpApplication
   {
      protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

           IKernel kernel = new StandardKernel();
           kernel.Bind<IShapeService>().To<ShapeService>().InSingletonScope();

           DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

      #region Dependency Resolver
      private class NinjectDependencyResolver : IDependencyResolver
      {
         private readonly IResolutionRoot _resolutionRoot;

         public NinjectDependencyResolver(IResolutionRoot kernel)
         {
            _resolutionRoot = kernel;
         }

         public object GetService(Type serviceType)
         {
            return _resolutionRoot.TryGet(serviceType);
         }

         public IEnumerable<object> GetServices(Type serviceType)
         {
            return _resolutionRoot.GetAll(serviceType);
         }
      }
      #endregion
   }
}
