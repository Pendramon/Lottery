using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Pendramon.Lottery.Data.Model;
using Microsoft.EntityFrameworkCore;
using Pendramon.RaffleConsole.Service.Interfaces;
using Pendramon.RaffleConsole.Service;
using Pendramon.RaffleConsole.Data;
using Pendramon.RaffleConsole.Data.Model.Enums;

namespace Pendramon.RaffleConsole.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Configure();

            var lotteryManager = serviceProvider.GetService<ILotteryService>();
            var configuration = serviceProvider.GetService<IConfigurationRoot>();

            var finalRaffle = DateTime.Parse(configuration.GetSection("FinalRaffle").Value);

            if(DateTime.Now.Date <= finalRaffle)
            {
                lotteryManager.GiveAwards(RaffledType.PerDay);
            }
            if(DateTime.Now.Date == finalRaffle)
            {
                lotteryManager.GiveAwards(RaffledType.Final);
            }
        }

        static ServiceProvider Configure()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true);

            IConfigurationRoot configuration = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddSingleton(provider => configuration)
                .AddSingleton<DbContext, LotteryContext>()
                .AddSingleton<ILotteryService, LotteryService>()
                .AddSingleton(typeof(IRepository<>), typeof(Repository<>))
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
