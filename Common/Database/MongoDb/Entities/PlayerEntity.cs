using Common.Interfaces;
using MongoDB.Bson;

namespace Common.Database.MongoDb.Entities
{
    public class PlayerEntity : IEntity
    {
        public ObjectId Id { get; set; }
        public uint UID { get; set; }
        public bool Banned { get; set; }
        public PlayerBasicInfo PlayerBasicInfo { get; set; }
    }
}