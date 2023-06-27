using MongoDB.Bson;

namespace Starlight.Database
{
    public interface IEntity
    {
        ObjectId Id { get; set; }
    }
}