using System.Linq;
using Pendramon.Lottery.Data.Model.Interfaces;
using System.Data.Entity;

namespace Pendramon.Lottery.Data
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {

        #region Database Set

        protected DbSet<T> DbSet;

        #endregion

        #region Constructor

        public Repository(DbContext dbContext)
        {
            DbSet = dbContext.Set<T>();
        }

        #endregion

        #region Public Methods

        public void Insert(T entity)
        {
            DbSet.Add(entity);
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
