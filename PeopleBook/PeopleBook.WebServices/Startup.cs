﻿using Microsoft.Owin;
using Owin;
using Ninject.Web.Common.OwinHost;
using Ninject;
using System.Reflection;
using PeopleBook.Data;
using System.Web.Http;
using Ninject.Web.WebApi.OwinHost;

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

            //kernel.Bind<IGameResultValidator>().To<GameResultValidator>();

            //kernel.Bind<IUserIdProvider>().To<AspNetUserIdProvider>();
        }
    }
}