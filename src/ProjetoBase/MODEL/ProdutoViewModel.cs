using ProjetoBase.DOMINIO;
using ProjetoBase.INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoBase.MODEL
{
    public class ProdutoViewModel : IViewModel
    {
        public Guid?  Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public IList<SerialViewModel> Seriais {get; set;}
    }
}
