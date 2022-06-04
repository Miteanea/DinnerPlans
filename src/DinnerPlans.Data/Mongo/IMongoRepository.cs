using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DeliverY.Data.Mongo
{
    public interface IMongoRepository<T>
    {
        Task<List<T>> LoadAllAsync(CancellationToken cancellationToken);
        Task<T> LoadSingleAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
        Task<List<T>> LoadAsync(Expression<Func<T, bool>> filter, FindOptions<T, T> findOptions, CancellationToken cancellationToken);
        Task<List<T>> LoadAsync(FilterDefinition<T> filter, FindOptions<T, T> findOptions, CancellationToken cancellationToken);
        Task InsertOneAsync(T document, CancellationToken cancellationToken);
        Task InsertManyAsync(IEnumerable<T> documents, CancellationToken cancellationToken);
        Task<RepoDeleteResult> DeleteOneAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
        Task<RepoDeleteResult> DeleteManyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
        Task<RepoReplaceOneResult> SaveOrUpdateOneAsync(T document, Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
    }

    public class MongoRepository<T> : IMongoRepository<T>
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(MongoConnection mongoConnection, String collectionName = null)
        {
            var mongoClient = new MongoClient(mongoConnection.DeliveryDb);
            _collection = mongoClient.GetDatabase(mongoConnection.DeliveryDbName).GetCollection<T>(collectionName ?? typeof(T).Name);
        }

        public async Task<List<T>> LoadAllAsync(CancellationToken cancellationToken)
        {
            return await LoadAsync(_ => true, null, cancellationToken);
        }

        public async Task<T> LoadSingleAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken)
        {
            var result = await _collection.FindAsync(filter, new FindOptions<T, T> { Limit = 1 }, cancellationToken);
            return await result.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<T>> LoadAsync(Expression<Func<T, bool>> filter, FindOptions<T, T> findOptions, CancellationToken cancellationToken)
        {
            var result = await _collection.FindAsync(filter, findOptions, cancellationToken);
            return await result.ToListAsync(cancellationToken);
        }

        public async Task InsertOneAsync(T document, CancellationToken cancellationToken)
        {
            await _collection.InsertOneAsync(document, new InsertOneOptions { BypassDocumentValidation = true }, cancellationToken);
        }

        public async Task InsertManyAsync(IEnumerable<T> documents, CancellationToken cancellationToken)
        {
            await _collection.InsertManyAsync(documents, null, cancellationToken);
        }

        public async Task<RepoDeleteResult> DeleteOneAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken)
        {
            var result = await _collection.DeleteOneAsync(filter, cancellationToken);
            return new RepoDeleteResult(result.DeletedCount);
        }

        public async Task<RepoDeleteResult> DeleteManyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken)
        {
            var result = await _collection.DeleteManyAsync(filter, cancellationToken);
            return new RepoDeleteResult(result.DeletedCount);
        }

        public async Task<RepoReplaceOneResult> SaveOrUpdateOneAsync(T document, Expression<Func<T, bool>> filter, CancellationToken cancellationToken)
        {
            var result = await _collection.ReplaceOneAsync(filter, document, new UpdateOptions() { IsUpsert = true }, cancellationToken);
            return new RepoReplaceOneResult(result);
        }

        public async Task<List<T>> LoadAsync(FilterDefinition<T> filter, FindOptions<T, T> findOptions, CancellationToken cancellationToken)
        {
            var result = await _collection.FindAsync(filter, findOptions, cancellationToken);
            return await result.ToListAsync(cancellationToken);
        }
    }
}