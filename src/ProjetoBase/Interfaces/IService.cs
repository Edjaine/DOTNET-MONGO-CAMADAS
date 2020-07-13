using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoBase.INTERFACES
{
    public interface IService<T>
    {
        Task<T> ConsultaPorId(Guid id);
        Task<List<T>> Consulta();
        Task<T> Atualiza(Guid id, T obj);
        Task<T> Insere(T obj);
        Task Remove(Guid id);
    }
}
