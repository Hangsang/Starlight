using MongoDB.Driver;
using Server.Interfaces;
using System.Linq.Expressions;

namespace Server.Database.MongoDb.Repositories
{
    public class BaseRepository<T> where T : IEntity
    {
        public static IMongoCollection<T> Collection { get; set; }

        public static async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await Collection.Find(expression).AnyAsync();
        }

        public static async Task<T> FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return await Collection.FindSync(expression).FirstOrDefaultAsync();
        }

        public static async ValueTask ReplaceOne(T entity)
        {
            await Collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }

        public static async ValueTask DeleteOne(T entity)
        {
            await Collection.DeleteOneAsync(x => x.Id == entity.Id);
        }

        public static async ValueTask InsertOne(T entity)
        {
            await Collection.InsertOneAsync(entity);
        }

        public static async Task<long> Count(Expression<Func<T, bool>> expression)
        {
            return await Collection.CountDocumentsAsync(expression);
        }

        public static async Task<long> CountAll()
        {
            return await Collection.CountDocumentsAsync(Builders<T>.Filter.Empty);
        }

        public async Task<IAsyncCursor<T>> FindMultiple(Expression<Func<T, bool>> expression)
        {
            return await Collection.FindAsync(expression);
        }

        public async Task<IList<T>> All()
        {
            return await Collection.Find(Builders<T>.Filter.Empty).ToListAsync();
        }

        public async Task<uint> GetNewId()
        {
            var x = await CountAll();
            x++;
            return (uint)x;
        }
    }
}