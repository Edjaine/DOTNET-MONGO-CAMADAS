using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoBase.INTERFACES;
using MongoDB.Driver;
using ServiceStack;

namespace ProjetoBase.INFRA.REPOSITORIO {
    public abstract class BaseRepositorio<TEntity> : IRepositorio<TEntity> where TEntity : IDominio {
        protected IMongoContext _context;
        protected IMongoCollection<TEntity> DbSet;
        public BaseRepositorio (IMongoContext context) {
            DbSet = context.GetCollection<TEntity>(typeof(TEntity).Name);
            _context = context;
        }
        public virtual void Add (TEntity obj) {
            _context.AddCommand (() => DbSet.InsertOneAsync (obj));
        }

        public void Dispose () {
            _context?.Dispose ();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll () {
            var all = await DbSet.FindAsync (Builders<TEntity>.Filter.Empty);
            return all.ToList ();
        }

        public virtual async Task<TEntity> GetById (Guid id) {
            var data = await DbSet.FindAsync (Builders<TEntity>.Filter.Eq ("_id", id));
            return data.SingleOrDefault ();
        }

        public virtual void Remove (Guid id) {
            _context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));
        }

        public virtual void Update (Guid id, TEntity obj) {         
            _context.AddCommand (() => DbSet.ReplaceOneAsync (Builders<TEntity>.Filter.Eq ("_id", obj.GetId ()), obj));
        }
    }
}
