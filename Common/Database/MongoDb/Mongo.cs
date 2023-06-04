using MongoDB.Driver;

namespace Common.Database.MongoDb
{
    internal class Mongo
    {
        public static MongoClient Client { get; set; }
        public static IMongoDatabase Database { get; set; }
    }
}