using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Pendramon.Lottery.Data.Model
{
    public class LotteryContext : DbContext
    {
        protected LotteryContext() : base("LotteryDb")
        {
        }

        public virtual DbSet<Code> Codes { get; set; }

        public virtual DbSet<Award> Awards { get; set; }

        public virtual DbSet<UserCode> UserCodes { get; set; }

        public virtual DbSet<UserCodeAward> UserCodeAwards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
