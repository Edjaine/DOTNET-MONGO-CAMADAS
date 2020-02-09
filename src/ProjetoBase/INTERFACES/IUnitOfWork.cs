using System;
using System.Threading.Tasks;

namespace estoque.INTERFACES {
    public interface IUnitOfWork : IDisposable {
        Task<bool> Commit ();

    }
}
