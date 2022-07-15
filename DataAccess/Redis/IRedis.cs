using StackExchange.Redis;

namespace DataAccess.Redis;

public interface IRedisHelper
{
    Task<bool> SetKey(string Key, string Value);
    Task<string> GetKey(string Key);
}

public class RedisHelper : IRedisHelper
{
    public async Task<bool> SetKey(string Key, string Value)
    {
        var database = await GetRedisDatabase();
        return await database.StringSetAsync(Key, Value);
    }

    public async Task<string> GetKey(string Key)
    {
        var database = await GetRedisDatabase();
        var value = await database.StringGetAsync(Key);
        return await Task.FromResult((string)value);
    }

    private async Task<IDatabase> GetRedisDatabase()
    {
        var config = new ConfigurationOptions
        {
            EndPoints = {"localhost"},
            Ssl = false,
            AbortOnConnectFail = false,
        };
        ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync(config);
        return redis.GetDatabase(0);
    }
}