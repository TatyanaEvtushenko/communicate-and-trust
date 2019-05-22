using System;
using System.Linq;
using CAT.DataLayer.Contextes;
using CAT.DataLayer.Repositories.DatabaseRepositories.Interfaces;

namespace CAT.DataLayer.Repositories.DatabaseRepositories
{
    public abstract class BaseDatabaseRepository<T> : IDatabaseRepository<T>
        where T: class
    {
        protected readonly ApplicationDbContext DbContext;

        protected BaseDatabaseRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public T GetFirst(Func<T, bool> predicate)
        {
            var entity = DbContext.Set<T>().FirstOrDefault(predicate);
            return entity;
        }

        public void Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
            DbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            DbContext.Set<T>().Update(entity);
            DbContext.SaveChanges();
        }

        public abstract IQueryable<T> QueryableList();
    }
}
