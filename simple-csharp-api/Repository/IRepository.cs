using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_csharp_api.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        List<T> Find();
        void Create(T entity);
        void Delete(T entity);
        //void Update(T entity);
        T Get(int id);
    }
}
