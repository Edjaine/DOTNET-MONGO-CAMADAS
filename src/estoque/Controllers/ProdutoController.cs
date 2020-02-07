using estoque.DOMINIO;
using estoque.INTERFACES;
using estoque.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace estoque.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase {
        private readonly IProdutoRepositorio _repositorio;
        private readonly IUnitOfWork _uow;
        public ProdutoController(IProdutoRepositorio repositorio, IUnitOfWork uow) {
            _repositorio = repositorio;
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<Produto>> Get() {
            var produtos = await _repositorio.GetAll();
            return Ok(produtos);
        }
        [HttpPost]
        public async Task<ActionResult<Produto>> Post([FromBody] ProdutoViewModel produtoViewModel)
        {
            try
            {
                var produto = produtoViewModel.GetProduto();
                _repositorio.Add(produto);
                await _uow.Commit();
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
