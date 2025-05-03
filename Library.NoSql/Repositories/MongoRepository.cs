using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.NoSql
{
    public class MongoRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(string connectionString, string dbName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbName);
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task AddAsync(T item) => await _collection.InsertOneAsync(item);

        public async Task<List<T>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();
    }
}
