using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace estoque.INTERFACES {
    public interface IRepositorio<TEntity> : IDisposable where TEntity : class {
        void Add (TEntity obj);
        Task<TEntity> GetById (Guid id);
        Task<IEnumerable<TEntity>> GetAll ();
        void Update (Guid id, TEntity obj);
        void Remove (Guid id);
    }
}
