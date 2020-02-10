using System;
using System.Threading.Tasks;

namespace ProjetoBase.INTERFACES {
    public interface IUnitOfWork : IDisposable {
        Task<bool> Commit ();

    }
}
