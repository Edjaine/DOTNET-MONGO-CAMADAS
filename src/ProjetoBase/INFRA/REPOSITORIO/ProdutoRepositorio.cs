using estoque.DOMINIO;
using estoque.INTERFACES;

namespace estoque.INFRA.REPOSITORIO {
    public class ProdutoRepositorio : BaseRepositorio<Produto>, IProdutoRepositorio {
        public ProdutoRepositorio (IMongoContext context) : base (context) { }
    }
}
