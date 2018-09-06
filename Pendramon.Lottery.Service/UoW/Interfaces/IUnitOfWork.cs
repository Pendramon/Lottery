using System;

namespace Pendramon.Lottery.Service.UoW.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits all changes;
        /// </summary>
        void Commit();
    }
}
