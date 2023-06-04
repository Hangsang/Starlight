using MongoDB.Bson;

namespace Common.Interfaces
{
    public interface IEntity
    {
        ObjectId Id { get; set; }
    }
}