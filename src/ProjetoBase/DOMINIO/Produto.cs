using System;

namespace estoque.DOMINIO {
    public class Produto {
        public Produto (Guid id, string codigo, string descricao) {
            Id = id;
            Codigo = codigo;
            Descricao = descricao;
        }

        public Produto (string codigo, string descricao) {
            Id = Guid.NewGuid ();
            Codigo = codigo;
            Descricao = descricao;
        }
        public Guid Id { get; private set; }
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
    }
}
