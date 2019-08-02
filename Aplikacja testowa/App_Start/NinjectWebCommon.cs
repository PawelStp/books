using Aplikacja_testowa.Abstracts;
using Aplikacja_testowa.App_Start;
using Aplikacja_testowa.DAL;
using Aplikacja_testowa.Repositories;
using Aplikacja_testowa.Services;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Ninject.Web.WebApi;
using System;
using System.Web;
using System.Web.Http;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace Aplikacja_testowa.App_Start
{

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

            return kernel;
        }
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IBookRepository>().To<BookRepository>().InRequestScope();
            kernel.Bind<IBookService>().To<BookService>().InRequestScope();
            kernel.Bind<BooksDbContext>().ToSelf().InRequestScope();
        }
    }
}