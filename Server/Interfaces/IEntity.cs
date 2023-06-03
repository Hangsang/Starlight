using MongoDB.Bson;

namespace Server.Interfaces
{
    public interface IEntity
    {
        ObjectId Id { get; set; }
    }
}