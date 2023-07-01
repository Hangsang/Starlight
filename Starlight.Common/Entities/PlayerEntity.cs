using MongoDB.Bson;
using Starlight.Common.Interfaces;

namespace Starlight.Common.Entities
{
    public class PlayerEntity : IEntity
    {
        public ObjectId Id { get; set; }
        public uint UID { get; set; }
        public string Username { get; set; }
        public bool Banned { get; set; }
        public PlayerBasicInfo PlayerBasicInfo { get; set; }
    }
}