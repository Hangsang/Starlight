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
    }
}