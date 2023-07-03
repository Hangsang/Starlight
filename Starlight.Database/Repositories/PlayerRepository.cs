using MongoDB.Bson;
using MongoDB.Driver;
using Starlight.Common.Entities;
using Starlight.Common.Interfaces;

namespace Starlight.Database.Repositories
{
    public class PlayerRepository : BaseRepository<PlayerEntity>, IRepository
    {
        public void Start()
        {
            Collection = Mongo.Database.GetCollection<PlayerEntity>("players");
        }

        public static async ValueTask<bool> Update(ObjectId id, UpdateType type, object value)
        {
            var _filter = Builders<PlayerEntity>.Filter.Eq(x => x.Id, id);
            if (_filter == null)
            {
                return false;
            }

            UpdateDefinition<PlayerEntity> _set = null;
            switch (type)
            {
                case UpdateType.Token:
                    _set = Builders<PlayerEntity>.Update.Set(x => x.Token, value);
                    break;
                case UpdateType.Username:
                    _set = Builders<PlayerEntity>.Update.Set(x => x.Username, value);
                    break;
                case UpdateType.UID:
                    _set = Builders<PlayerEntity>.Update.Set(x => x.UID, value);
                    break;
                case UpdateType.BanInfo:
                    _set = Builders<PlayerEntity>.Update.Set(x => x.Banned, value);
                    break;
                case UpdateType.BasicInfo:
                    _set = Builders<PlayerEntity>.Update.Set(x => x.PlayerBasicInfo, value);
                    break;
            }

            if (_set != null) {
                var _update = await Collection.UpdateOneAsync(_filter, _set);
                return _update.ModifiedCount > 0;
            }

            return false;
        }

        public enum UpdateType
        {
            Token,
            UID,
            Username,
            BasicInfo,
            BanInfo
        }
    }
}