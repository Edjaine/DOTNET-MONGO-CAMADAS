using System;

namespace ProjetoBase.MODEL
{
    public class SerialViewModel
    {
        public Guid? Id { get; set; }
        public Guid IdProduto {get; set;}
        public string Valor { get; set; }
        public string Lote { get; set; }
    }
}