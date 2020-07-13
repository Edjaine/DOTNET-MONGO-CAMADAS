using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoBase.INTERFACES;

namespace ProjetoBase.INTERFACES {
    public interface IRepositorio<TEntity> : IDisposable where TEntity : IDominio {
        void Add (TEntity obj);
        Task<TEntity> GetById (Guid id);
        Task<IEnumerable<TEntity>> GetAll ();
        void Update (Guid id, TEntity obj);
        void Remove (Guid id);
    }
}
