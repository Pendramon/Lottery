using Autofac;
using Pendramon.Lottery.Data.Model;
using System.Data.Entity;
using Pendramon.Lottery.Data;

namespace Pendramon.Lottery.Service.IoC
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LotteryContext>().As<DbContext>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
        }
    }
}
