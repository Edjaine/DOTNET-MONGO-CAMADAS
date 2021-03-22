using System;
using System.Collections.Generic;
using Bogus;
using ProjetoBase.DOMINIO;

namespace test
{
    public static class FactoryProduto
    {
        public static Produto Constroi(){
            var faker = new Faker();
            var produto = new Produto(Guid.NewGuid(),$"PROD-{faker.Lorem.Word()}", faker.Lorem.Text());
            return produto;
        }
        public static IList<Produto> Constroi(int quantidade){
            var produtos = new List<Produto>();

            for(var i = 0; i < quantidade; i++){
                produtos.Add(FactoryProduto.Constroi());
            } 

            return produtos;

        }
    }
}