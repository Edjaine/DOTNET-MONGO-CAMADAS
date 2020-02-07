using System.Threading.Tasks;
using estoque.INTERFACES;

namespace estoque.INFRA.UoW {
    public class UnitOfWork : IUnitOfWork {
        private readonly IMongoContext _context;
        public UnitOfWork (IMongoContext context) {
            _context = context;
        }
        public async Task<bool> Commit () {
            var chargeAmount = await _context.SaveChanges ();
            return chargeAmount > 0;
        }
        public void Dispose () {
            _context.Dispose ();
        }
    }
}
