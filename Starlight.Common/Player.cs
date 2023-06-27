using MongoDB.Bson;
using Starlight.Common.Interfaces;

namespace Starlight.Common
{
    public class Player : IEntity
    {
        public ObjectId Id { get; set; }
        public uint UID { get; set; }
        public bool Banned { get; set; }
        public PlayerBasicInfo PlayerBasicInfo { get; set; }
    }
}