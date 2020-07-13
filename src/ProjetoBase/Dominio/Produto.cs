using System;
using System.Collections.Generic;
using ProjetoBase.INTERFACES;

namespace ProjetoBase.DOMINIO {
    public class Produto : IDominio {
        public Produto (Guid id, string codigo, string descricao) {
            Id = id;
            Codigo = codigo;
            Descricao = descricao;
        }

        public Produto (string codigo, string descricao) {
            Id = Guid.NewGuid ();
            Seriais = new List<Serial>();
            Codigo = codigo;
            Descricao = descricao;
        }

        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public List<Serial> Seriais{ get; set;} 
    }
}
