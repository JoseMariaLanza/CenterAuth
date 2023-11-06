using System.Text.Json;
using StackExchange.Redis;

namespace CenterAuth.Services
{
    public class RedisService : IRedisService
    {
        private readonly IRedisHelper _redisHelper;

        public RedisService(IRedisHelper redisHelper)
        {
            _redisHelper = redisHelper;
        }

        public async Task<bool> SetStringAsync(string key, string value)
        {
            var database = _redisHelper.GetDatabase();
            return await database.StringSetAsync(key, value);
        }

        public async Task<string?> GetStringAsync(string key)
        {
            var database = _redisHelper.GetDatabase();
            return await database.StringGetAsync(key);
        }

        public async Task<bool> RemoveKeyAsync(string key)
        {
            var database = _redisHelper.GetDatabase();
            return await database.KeyDeleteAsync(key);
        }
    }
}
