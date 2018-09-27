using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pendramon.RaffleConsole.Data.Model;

namespace Pendramon.Lottery.Data.Model
{
    public class LotteryContext : DbContext
    {

        #region Private Members

        private readonly IConfigurationRoot configuration;

        #endregion

        #region Constructor

        public LotteryContext(IConfigurationRoot configuration)
        {
            this.configuration = configuration;
        }

        #endregion

        #region Database Sets

        public virtual DbSet<Code> Codes { get; set; }

        public virtual DbSet<Award> Awards { get; set; }

        public virtual DbSet<UserCode> UserCodes { get; set; }

        public virtual DbSet<UserCodeAward> UserCodeAwards { get; set; }

        #endregion

        #region Configuration Override

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("LotteryDatabase"));
        }

        #endregion

    }
}
