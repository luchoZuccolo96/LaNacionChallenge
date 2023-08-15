using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChallengeLaNacion.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Find(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<int> Save();
        Task<IEnumerable<T>> FindWhere(string key, string searchValue);
    }
}