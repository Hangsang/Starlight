using MongoDB.Bson;

namespace Starlight.Common.Interfaces
{
    public interface IEntity
    {
        ObjectId Id { get; set; }
    }
}