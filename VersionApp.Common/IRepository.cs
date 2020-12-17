using System;
using System.Linq;
using VersionApp.Common.MVVM;

namespace VersionApp.Common
{
    public interface IRepository
    {
        #region Methods

        void Clear(bool commit = true);

        void ContextAction(Action action, bool commit);

        byte[] GetLatestVersion();

        #endregion
    }

    public interface IRepository<T> : IRepository where T : class, IModel
    {
        #region Methods

        T Add(T model, bool commit = true);

        T AddOrUpdate(T entity, bool commit = true);

        T Delete(T model, bool commit = true);

        IQueryable<T> Get();

        T Get(Guid id);

        T Update(T model, bool commit = true);

        #endregion
    }
}