using System;
using ProjetoBase.INTERFACES;

namespace ProjetoBase.DOMINIO
{
    public class Serial : IDominio
    {
        public Serial(Guid id, string valor, string lote, Guid idProduto)
        {
            Id = id;
            IdProduto = idProduto;
            Valor = valor;
            Lote = lote;
        }
        public Serial(string valor, string lote, Guid idProduto)
        {
            Id = Guid.NewGuid();
            IdProduto = idProduto;
            Valor = valor;
            Lote = lote;
        }
        public Guid Id { get; set; }
        public Guid IdProduto {get; private set;}
        public string Valor { get; private set; }
        public string Lote { get; private set; }
        
    }
}