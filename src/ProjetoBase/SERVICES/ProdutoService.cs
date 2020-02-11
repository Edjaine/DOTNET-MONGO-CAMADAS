using AutoMapper;
using ProjetoBase.DOMINIO;
using ProjetoBase.INTERFACES;
using ProjetoBase.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoBase.SERVICES
{
    public class ProdutoService: IProdutoService
    {
        private readonly IUnitOfWork _uow;
        private readonly IProdutoRepositorio _repositorio;
        private readonly IMapper _mapper;
        public ProdutoService(IProdutoRepositorio repositorio, IUnitOfWork uow, IMapper mapper){        
            _uow = uow;
            _repositorio = repositorio;
            _mapper = mapper;
        }
        public async Task<ProdutoViewModel> ConsultaPorId(Guid id){        
            var produto = await _repositorio.GetById(id);
            return _mapper.Map<ProdutoViewModel>(produto);
        }
        public async Task<List<ProdutoViewModel>> Consulta(){
            var produtos = await _repositorio.GetAll();
            var produtosViewModel = new List<ProdutoViewModel>();

            produtos.ToList().ForEach(p => {
                produtosViewModel.Add(_mapper.Map<ProdutoViewModel>(p));
            });
            return produtosViewModel;
        }
        public async Task<ProdutoViewModel> Atualiza(Guid id, ProdutoViewModel produtoViewModel){
            var produto = _mapper.Map<Produto>(produtoViewModel);
            _repositorio.Update(id, produto);
            await _uow.Commit();
            var produtoPersistido = _repositorio.GetById(id);
            return _mapper.Map<ProdutoViewModel>(produtoPersistido);
        }
        public async Task<ProdutoViewModel> Insere(ProdutoViewModel produtoViewModel){
            var produto = _mapper.Map<Produto>(produtoViewModel);
            _repositorio.Add(produto);
            await _uow.Commit();            
            var produtoPersistido = _repositorio.GetById(produto.Id);
            return _mapper.Map<ProdutoViewModel>(produtoPersistido);
        }
        public async Task Remove(Guid id){
            _repositorio.Remove(id);
            await _uow.Commit();
        }
        public async Task<ProdutoViewModel> InsereSeriail(SerialViewModel serialViewModel){            
            var serial = _mapper.Map<Serial>(serialViewModel);
            _repositorio.AddSerial(serial);
            await _uow.Commit();
            var produtoPersistido = await _repositorio.GetById(serialViewModel.IdProduto);
            if(produtoPersistido == null)
                return new ProdutoViewModel();

            return _mapper.Map<ProdutoViewModel>(produtoPersistido);
        } 
    }
}
