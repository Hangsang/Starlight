using MongoDB.Driver;
using Starlight.Common.Interfaces;
using System.Linq.Expressions;

namespace Starlight.Database.Repositories
{
    public class BaseRepository<T> where T : IEntity
    {
        public static IMongoCollection<T> Collection { get; set; }

        public static async ValueTask<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await Collection.Find(expression).AnyAsync();
        }

        public static async ValueTask<T> FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return await Collection.FindSync(expression).FirstOrDefaultAsync();
        }

        public static async Task ReplaceOne(T entity)
        {
            await Collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }

        public static async Task DeleteOne(T entity)
        {
            await Collection.DeleteOneAsync(x => x.Id == entity.Id);
        }

        public static async Task InsertOne(T entity)
        {
            await Collection.InsertOneAsync(entity);
        }

        public static async ValueTask<long> Count(Expression<Func<T, bool>> expression)
        {
            return await Collection.CountDocumentsAsync(expression);
        }

        public static async ValueTask<long> CountAll()
        {
            return await Collection.CountDocumentsAsync(Builders<T>.Filter.Empty);
        }

        public async ValueTask<IAsyncCursor<T>> FindMultiple(Expression<Func<T, bool>> expression)
        {
            return await Collection.FindAsync(expression);
        }

        public async ValueTask<IList<T>> All()
        {
            return await Collection.Find(Builders<T>.Filter.Empty).ToListAsync();
        }

        public async ValueTask<uint> GetNewId()
        {
            var x = await CountAll();
            x++;
            return (uint)x;
        }
    }
}