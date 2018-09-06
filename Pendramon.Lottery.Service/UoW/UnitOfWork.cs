using Pendramon.Lottery.Service.UoW.Interfaces;
using System.Data.Entity;

namespace Pendramon.Lottery.Service.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        #region Private Members

        private readonly DbContext dbContext;

        #endregion

        #region Constructor

        public UnitOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
        }

        #endregion

    }
}
