using estoque.DOMINIO;
using estoque.INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estoque.SERVICES
{
    public class ProdutoService: IService
    {
        private readonly IUnitOfWork _uow;
        private readonly IProdutoRepositorio _repositorio;
        public ProdutoService(IProdutoRepositorio repositorio, IUnitOfWork uow)
        {
            _uow = uow;
            _repositorio = repositorio;
        }
        public async Task<Produto> GetById(Guid id)
        {
            return await _repositorio.GetById(id);
        }
    }
}
