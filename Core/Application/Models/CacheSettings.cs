namespace Application.Models;

public class CacheSettings
{
    public int SlidingExpiration { get; set; }
    public string RedisConnectionString { get; set; }
    public string RedisInstanceName { get; set; }
    public bool BypassCache { get; set; }
}
