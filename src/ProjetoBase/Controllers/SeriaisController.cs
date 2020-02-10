using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoBase.INTERFACES;
using ProjetoBase.MODEL;

namespace ProjetoBase.Controllers
{
    [Route("controller")]
    [ApiController]
    public class SeriaisController: ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public SeriaisController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Post(SerialViewModel serialViewModel){
            var produtoViewModel = await _produtoService.InsereSeriail(serialViewModel);
            return produtoViewModel;
        }
    }
}