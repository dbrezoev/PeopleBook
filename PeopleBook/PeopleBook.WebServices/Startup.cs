using Microsoft.Owin;
using Owin;
using Ninject.Web.Common.OwinHost;
using Ninject;
using Ninject.Extensions.Conventions;
using System.Reflection;
using PeopleBook.Data;
using System.Web.Http;
using Ninject.Web.WebApi.OwinHost;
using PeopleBook.DomainServices.Contracts;
using PeopleBook.DomainServices.Data;

[assembly: OwinStartup(typeof(PeopleBook.WebServices.Startup))]

namespace PeopleBook.WebServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);
            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IPeopleBookData>().To<PeopleBookData>()
                .WithConstructorArgument("context",
                    c => new PeopleBookDbContext());

            //kernel.Bind<IBookService>().To<BookService>();
            //kernel.

            kernel.Bind(k => k
                .From(
                    "PeopleBook.DomainServices")
                .SelectAllClasses()
                .InheritedFrom<IService>()
                .BindDefaultInterface());

            //kernel.Bind<IUserIdProvider>().To<AspNetUserIdProvider>();
        }
    }
}
