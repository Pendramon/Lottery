using System.Linq;
using Pendramon.RaffleConsole.Data.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Pendramon.RaffleConsole.Data
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {

        #region Database Set

        protected DbSet<T> DbSet;
        private readonly DbContext dbContext;

        #endregion

        #region Constructor

        public Repository(DbContext dbContext)
        {
            DbSet = dbContext.Set<T>();
            this.dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public void Insert(T entity)
        {
            DbSet.Add(entity);
            this.dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        #endregion

    }
}
