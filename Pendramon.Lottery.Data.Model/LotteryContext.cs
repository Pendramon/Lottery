using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Pendramon.Lottery.Data.Model
{
    public class LotteryContext : DbContext
    {

        #region Constructor

        protected LotteryContext() : base("LotteryDb")
        {
        }

        #endregion

        #region Database Sets

        public virtual DbSet<Code> Codes { get; set; }

        public virtual DbSet<Award> Awards { get; set; }

        public virtual DbSet<UserCode> UserCodes { get; set; }

        public virtual DbSet<UserCodeAward> UserCodeAwards { get; set; }

        #endregion

        #region Convention Overrides

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        #endregion

    }
}
