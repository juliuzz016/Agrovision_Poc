using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SprayCalculatorRepository
{
    public abstract class RepositoryBase<T>
    {
        public abstract Task<(long RecordsAffected, T Entity)> Create(T entity);
        public abstract Task<long> Delete(T entity);
        public abstract Task<long> Delete(Guid Key);
        public abstract Task<IEnumerable<T>> Lookup(Expression<Func<T, bool>> queryData, int skip, int take);
        public abstract Task<IEnumerable<T>> Lookup(Expression<Func<T, bool>> queryData);
        public abstract Task<long> Update(T entity);
    }
}
