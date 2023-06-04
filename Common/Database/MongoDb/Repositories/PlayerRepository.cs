using Common.Database.MongoDb.Entities;
using Common.Interfaces;

namespace Common.Database.MongoDb.Repositories
{
    public class PlayerRepository : BaseRepository<PlayerEntity>, IRepository
    {
        public void Start()
        {
            Collection = Mongo.Database.GetCollection<PlayerEntity>("players");
        }

        /*
        public static async Task<bool> Insert(PlayerEntity character)
        {
            try
            {
                await Collection.InsertOneAsync(character);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public static async Task<List<PlayerEntity>> FindAll()
        {
            return await Collection.Find(Builders<PlayerEntity>.Filter.Empty).ToListAsync();
        }

        public static async Task<List<PlayerEntity>> FindAllChars(uint AccountId)
        {
            return (await Collection.FindAsync(x => x.AccountId == AccountId)).ToList();
        }

        public static async Task<byte> GetCharacterCount(uint accountId)
        {
            return (byte)await Collection.CountDocumentsAsync(x => x.AccountId == accountId);
        }

        public static async Task<bool> IsNameTaken(string nickname)
        {
            return await (await Collection.FindAsync(x => x.Nickname == nickname)).AnyAsync();
        }

        public static async ValueTask DeleteCharacter(uint CharacterId)
        {
            await Collection.DeleteOneAsync(x => x.CharacterId == CharacterId);
        }

        public static async ValueTask DeleteSlot(byte slot)
        {
            await Collection.DeleteOneAsync(x => x.Slot == slot);
        }

        public static async Task<bool> TestUpdate(string characterUID, int itemUID, InventorySubEntity item)
        {
            var character = FirstOrDefault(x => x.Id == ObjectId.Parse(characterUID));

            var update = Builders<PlayerEntity>.Update.Combine(
            Builders<PlayerEntity>.Update.Set(x => x.Items[-1], item));

            var filter = Builders<PlayerEntity>.Filter.And(
                Builders<PlayerEntity>.Filter.Eq(x => x.Id, ObjectId.Parse(characterUID)),
                Builders<PlayerEntity>.Filter.ElemMatch(x => x.Items, x => x.UniqueId == itemUID));

            var result = await Collection.UpdateOneAsync(filter, update);

            return result.IsAcknowledged
                   && result.ModifiedCount > 0;
        }
        */
    }
}