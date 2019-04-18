using System;

namespace CAT.DataLayer.Repositories.BaseRepositories.Interfaces
{
    public interface IDatabaseRepository<T>
    {
        T GetFirst(Func<T, bool> predicate);

        void Add(T entity);

        void Update(T entity);
    }
}
