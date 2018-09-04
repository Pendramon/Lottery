using Pendramon.Lottery.Data.Model.Interfaces;
using System.Linq;

namespace Pendramon.Lottery.Data
{
    public interface IRepository<T> where T : IEntity
    {
        void Insert(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
