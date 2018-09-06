using Autofac;
using Autofac.Integration.WebApi;
using Pendramon.Lottery.Service;
using Pendramon.Lottery.Service.Interfaces;
using Pendramon.Lottery.Service.IoC;
using System.Reflection;
using System.Web.Http;

namespace Pendramon.Lottery.Web.App_Start
{
    public class IocConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterDependencies(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterDependencies(ContainerBuilder builder)
        {
            //Register your web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<LotteryServiceV0>().As<ILotteryService>().InstancePerRequest();

            builder.RegisterModule(new ServiceModule());

            return builder.Build();
        }

    }
}