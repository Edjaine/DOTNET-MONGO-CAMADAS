using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using ProjetoBase.DOMINIO;
using ProjetoBase.INTERFACES;

namespace ProjetoBase.INFRA.REPOSITORIO {
    public class ProdutoRepositorio : BaseRepositorio<Produto>, IProdutoRepositorio {
        public ProdutoRepositorio (IMongoContext context) : base (context) { }

        public void AddSerial(Serial serial)
        {
            _context.AddCommand(() => {
                var p = DbSet.Find(Builders<Produto>.Filter.Eq("_id", serial.IdProduto)).SingleOrDefault();
                if (p != null){
                    if (p.Seriais == null)
                        p.Seriais = new List<Serial>();
                    p.Seriais.Add(serial);
                    return DbSet.ReplaceOneAsync(Builders<Produto>.Filter.Eq("_id", p.Id),p);
                }
                return Task.FromResult(false);
            });
        }
    }
}
