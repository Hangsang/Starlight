using MongoDB.Bson;
using Starlight.Database;

namespace Starlight.Common.Entity
{
    public class Player : IEntity
    {
        public ObjectId Id { get; set; }
        public uint UID { get; set; }
        public bool Banned { get; set; }
        public PlayerBasicInfo PlayerBasicInfo { get; set; }
    }
}