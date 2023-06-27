using MongoDB.Driver;

namespace Starlight.Database
{
    public class Mongo
    {
        public static MongoClient Client { get; set; }
        public static IMongoDatabase Database { get; set; }
    }
}