using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StolovkaWebAPI.Models
{
    public class UserRepository : IRepository<User>
    {
        private readonly UserContext _context = null;

        public UserRepository(IOptions<Settings> settings)
        {
            _context = new UserContext(settings);
        }

        public async Task<IEnumerable<User>> GetAllItems()
        {
            try
            {
                return await _context.Users
                        .Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // query after Id or InternalId (BSonId value)
        //
        public async Task<User> GetItem(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                return await _context.Users
                                .Find(Item => Item.Id == id
                                        || Item.InternalId == internalId)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        private ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        public async Task AddItem(User item)
        {
            try
            {
                await _context.Users.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveItem(string id)
        {
            try
            {
                DeleteResult actionResult
                    = await _context.Users.DeleteOneAsync(
                        Builders<User>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateItem(string id, User item)
        {
            try
            {
                ReplaceOneResult actionResult
                    = await _context.Users
                                    .ReplaceOneAsync(n => n.Id.Equals(id)
                                            , item
                                            , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveAllItems()
        {
            try
            {
                DeleteResult actionResult
                    = await _context.Users.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
