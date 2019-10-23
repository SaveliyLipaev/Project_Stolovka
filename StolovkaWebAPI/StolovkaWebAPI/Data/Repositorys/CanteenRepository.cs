﻿using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StolovkaWebAPI.Models
{
    public class CanteenRepository : ICanteenRepository
    {
        private readonly CanteenContext _context = null;

        public CanteenRepository(IOptions<Settings> settings)
        {
            _context = new CanteenContext(settings);
        }

        public async Task<IEnumerable<Canteen>> GetAllItems()
        {
            try
            {
                return await _context.Canteens.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<Canteen> GetItem(string id)
        {
            try
            {
                return await _context.Canteens.Find(Item =>
                    Item.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddItem(Canteen item)
        {
            try
            {
                await _context.Canteens.InsertOneAsync(item);
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
                    = await _context.Canteens.DeleteOneAsync(
                        Builders<Canteen>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateItem(string id, Canteen item)
        {
            try
            {
                ReplaceOneResult actionResult
                    = await _context.Canteens
                                    .ReplaceOneAsync(new BsonDocument("Id", id)
                                            , item
                                            , new UpdateOptions { IsUpsert = true });

                return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
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
                    = await _context.Canteens.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
