using estoque.DOMINIO;
using estoque.INTERFACES;
using estoque.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;

namespace estoque.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase {
        private readonly IProdutoRepositorio _repositorio;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ProdutoController(IProdutoRepositorio repositorio, IUnitOfWork uow, IMapper mapper) {
            _repositorio = repositorio;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Produto>> Get() {
            var produtos = await _repositorio.GetAll();
            return Ok(produtos);
        }
        [HttpPost]
        public async Task<ActionResult<Produto>> Post([FromBody] ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);            
            _repositorio.Add(produto);
            await _uow.Commit();
            return Ok(produto);           

        }

        [HttpPut]
        public async Task<ActionResult<Produto>> Put(Guid id, [FromBody] ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            _repositorio.Update(id, produto);
            await _uow.Commit();
            return Ok(produto);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id){
            _repositorio.Remove(id);
            await _uow.Commit();
            return Ok();
        }
    }
}
