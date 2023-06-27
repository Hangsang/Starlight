using Starlight.Common;
using Starlight.Common.Interfaces;

namespace Starlight.Database.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IRepository
    {
        public void Start()
        {
            Collection = Mongo.Database.GetCollection<Player>("players");
        }
    }
}