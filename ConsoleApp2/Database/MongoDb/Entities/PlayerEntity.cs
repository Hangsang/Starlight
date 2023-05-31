using MongoDB.Bson;
using Server.Interfaces;
using System.Xml;

namespace Server.Database.MongoDb.Entities
{
    public class PlayerEntity : IEntity
    {
        public ObjectId Id { get; set; }
        public uint UID { get; set; }
        public BEPIDFNIMLN PlayerBasicInfo { get; set; }
    }
}