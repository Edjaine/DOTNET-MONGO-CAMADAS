using ProjetoBase.DOMINIO;
using ProjetoBase.INTERFACES;
using ProjetoBase.MODEL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;

namespace ProjetoBase.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService) {
            _produtoService = produtoService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoViewModel>> Get(string id){
            var chave= Guid.Parse(id);
            var produtos = await _produtoService.ConsultaPorId(chave);
            return Ok(produtos);
        }
        [HttpGet]
        public async Task<ActionResult<ProdutoViewModel>> Get() {
            var produtos = await _produtoService.Consulta();
            return Ok(produtos);
        }
        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Post([FromBody] ProdutoViewModel produtoViewModel)
        {
            var produto = await _produtoService.Insere(produtoViewModel);
            return Ok(produto);           
        }
        [HttpPut]
        public async Task<ActionResult<ProdutoViewModel>> Put(Guid id, [FromBody] ProdutoViewModel produtoViewModel)
        {
            var produto = await _produtoService.Atualiza(id, produtoViewModel);
            return Ok(produto);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id){
            await _produtoService.Remove(id);
            return Ok();
        }
    }
}
