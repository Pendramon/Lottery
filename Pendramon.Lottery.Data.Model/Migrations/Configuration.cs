using Pendramon.Lottery.Data.Model.Enums;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Pendramon.Lottery.Data.Model.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LotteryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

        }

        protected override void Seed(LotteryContext context)
        {
            var codes = new List<Code>
            {
                new Code
                {
                    CodeValue = "CC8899",
                    IsWinning = true
                },
                new Code
                {
                    CodeValue = "CC7799",
                    IsWinning = false
                },
                new Code
                {
                    CodeValue = "CC6699",
                    IsWinning = false
                },
                new Code
                {
                    CodeValue = "CC5599",
                    IsWinning = true
                }
            };

            context.Codes.AddRange(codes);

            var awards = new List<Award>
            {
                new Award
                {
                    AwardName = "Beer",
                    AwardDescription = "You won a beer",
                    Quantity = 100,
                    RuffledType = (byte) RuffledType.Immediate
                },
                new Award
                {
                    AwardName = "iPhone",
                    AwardDescription = "You won an iPhone",
                    Quantity = 2,
                    RuffledType = (byte) RuffledType.PerDay
                },
                new Award
                {
                    AwardName = "VW Polo",
                    AwardDescription = "You won a Polo",
                    Quantity = 1,
                    RuffledType = (byte) RuffledType.Final
                }
            };

            context.Awards.AddRange(awards);

            context.SaveChanges();
        }
    }
}
