using Starlight.Common.Entity;

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