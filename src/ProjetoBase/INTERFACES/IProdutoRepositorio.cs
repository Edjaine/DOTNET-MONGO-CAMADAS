using System.Threading.Tasks;
using ProjetoBase.DOMINIO;

namespace ProjetoBase.INTERFACES {
    public interface IProdutoRepositorio : IRepositorio<Produto>  {
        void AddSerial(Serial serial);

    }
}
