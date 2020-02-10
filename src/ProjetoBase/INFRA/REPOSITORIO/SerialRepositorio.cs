using ProjetoBase.INTERFACES;
using ProjetoBase.DOMINIO;

namespace ProjetoBase.INFRA.REPOSITORIO
{
    public class SerialRepositorio : BaseRepositorio<Serial>, ISerialRepositorio
    {
        public SerialRepositorio(IMongoContext context) : base(context)
        {

        }
        public override void Add(Serial obj){
            _context.AddCommand(() => DbSet.InsertOneAsync(obj));   
        }
    }
}