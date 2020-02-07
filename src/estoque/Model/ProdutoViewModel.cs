using estoque.DOMINIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estoque.Model
{
    public class ProdutoViewModel
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }


        public Produto GetProduto()
        {
            return new Produto(Codigo, Descricao);
        } 
    }
}
