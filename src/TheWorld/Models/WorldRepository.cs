using System;
using System.Collections.Generic;
using ServiceStack.Redis;
using TheWorld.Services;
using Microsoft.Framework.Logging;

namespace TheWorld.Models
{
    public class WorldRepository : IWorldRepository
    {
        private ILogger<WorldContext> _logger;
        private RedisClient _client;
        public WorldRepository(ILogger<WorldContext> logger)
        {
            this._logger = logger;
           
        }

        public void AddTrip(Trip T)
        {
            using (var redisManager = new PooledRedisClientManager())
            {
                using (_client = new RedisClient())
                {
                    var redisTrip = _client.As<Trip>();
                    redisTrip.Store(T);
                }
            }
        }

        public IList<Trip> GetAllTrips()
        {
            try
            {
                using (_client = new RedisClient())
                {
                  return  _client.GetAll<Trip>();
                }
                  
            }
            catch(Exception ex)
            {
                _logger.LogError("", ex);

                return null;
            }
        }

        public List<Trip> GetAllTripsWithStops()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
