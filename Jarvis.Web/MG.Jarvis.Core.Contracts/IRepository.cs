using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MG.Jarvis.Core.Contracts
{
    public interface IRepository<T, U>
     where T : class, IIdentifiableModel<U>
    {
        void Add(T newEntity);
        void Remove(T entity);
        void Remove(U id);
        T Get(U id);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        bool SaveChanges();

        Task<long> ExecuteStoredProcedure(string storedProcedurename, object[] parameterCollection);
    }
}
