using System.Threading.Tasks;
using ProjetoBase.MODEL;

namespace ProjetoBase.INTERFACES
{
    public interface IProdutoService : IService<ProdutoViewModel>
    {
         public Task<ProdutoViewModel> InsereSeriail(SerialViewModel serialViewModel);
    }
}