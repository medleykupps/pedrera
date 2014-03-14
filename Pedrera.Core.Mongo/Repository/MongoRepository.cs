using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using Pedrera.Core.Repository;

namespace Pedrera.Core.Mongo.Repository
{
    public class MongoRepository<T, TId> : IRepository<T, TId>
        where T : IIdentifiable<TId>
    {
        private readonly IClassMap _classmap;

        private readonly string _connectionString = @"";
        private readonly string _databaseName = @"";
        private readonly string _collectionName = @"";

        public MongoRepository(string connectionString, string databaseName, string collectionName, IClassMap classmap)
        {
            if (String.IsNullOrEmpty(collectionName))
            {
                throw new ArgumentNullException("collectionName", "Must provide a collection name");
            }
            if (String.IsNullOrEmpty(databaseName))
            {
                throw new ArgumentNullException("databaseName", "Must provide a database name");
            }

            _collectionName = collectionName;
            _classmap = classmap;
            _databaseName = databaseName;
            _connectionString = connectionString;
        }

        private MongoClient Client
        {
            get
            {
                return _client ??
                       (_client = String.IsNullOrEmpty(_connectionString)
                           ? new MongoClient()
                           : new MongoClient(_connectionString));
            }
        }

        private MongoClient _client;

        private MongoCollection<T> Collection
        {
            get { return _collection ?? Database.GetCollection<T>(_collectionName); }
        }

        private MongoCollection<T> _collection;

        private MongoDatabase Database
        {
            get { return _database ?? _client.GetServer().GetDatabase(_databaseName); }
        }

        private MongoDatabase _database;

        public IEnumerable<T> GetAll()
        {
            return Collection.FindAll();
        }

        public IEnumerable<T> GetBy(Func<T, bool> predicate)
        {
            return Collection.AsQueryable().Where(predicate);
        }

        public T GetSingle(Func<T, bool> predicate)
        {
            return Collection.AsQueryable().SingleOrDefault(predicate);
        }

        public T GetSingle(TId id)
        {
            return Collection.FindOne(Query<T>.EQ(e => e.Id, id));
        }

        public T Insert(T entity)
        {
            var result = Collection.Insert(entity, WriteConcern.Acknowledged);
            if (result.Ok)
            {
                return entity;
            }
            return default(T);
        }

        public bool Update(T entity)
        {
            return Collection.Save(entity).DocumentsAffected > 0;
        }

        public bool Delete(T entity)
        {
            return Collection.Remove(Query<T>.EQ(e => e.Id, entity.Id)).DocumentsAffected == 1;
        }

        public bool Delete(TId id)
        {
            throw new NotImplementedException();
        }
    }
}
