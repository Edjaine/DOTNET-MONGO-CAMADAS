using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoBase.INTERFACES;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ProjetoBase.INFRA.CONTEXTO {
    public class MongoContext : IMongoContext {
        private readonly IConfiguration _configuration;
        private readonly List<Func<Task>> _commands;
        public IMongoDatabase Database { get; private set; }
        public IClientSessionHandle Session { get; private set; }
        public MongoClient MongoClient { get; private set; }

        public MongoContext (IConfiguration configuration) {
            _configuration = configuration;
            _commands = new List<Func<Task>> ();
            MongoClient = new MongoClient (_configuration.GetConnectionString ("mongo"));
            Database = MongoClient.GetDatabase (_configuration.GetSection ("Database").Value);
        }
        public void AddCommand (Func<Task> func) {
            _commands.Add (func);
        }

        public void Dispose () {
            Session?.Dispose ();
            GC.SuppressFinalize (this);
        }

        public IMongoCollection<T> GetCollection<T> (string nome) {
            return Database.GetCollection<T> (nome);
        }

        public async Task<int> SaveChanges () {
            using (Session = await MongoClient.StartSessionAsync ()) {
                Session.StartTransaction();
                var commandTask = _commands.Select (c => c ());
                await Task.WhenAll (commandTask);
                await Session.CommitTransactionAsync ();
            }
            return _commands.Count;
        }
    }
}
