using MongoDB.Bson;
using Server.Interfaces;

namespace Server.Database.MongoDb.Entities
{
    public class PlayerEntity : IEntity
    {
        public ObjectId Id { get; set; }
        public uint UID { get; set; }
        public bool Banned { get; set; }
        public BEPIDFNIMLN PlayerBasicInfo { get; set; }
    }
}