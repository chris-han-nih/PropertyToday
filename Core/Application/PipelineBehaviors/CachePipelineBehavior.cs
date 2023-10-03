namespace Application.PipelineBehaviors;

using System.Text;
using System.Text.Json;
using Application.Models;
using Application.PipelineBehaviors.Contracts;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

public class CachePipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ICacheable
{
    private readonly IDistributedCache _cache;
    private readonly CacheSettings _cacheSettings;
    
    public CachePipelineBehavior(IDistributedCache cache, IOptions<CacheSettings> cacheSettings)
    {
        _cache = cache;
        _cacheSettings = cacheSettings.Value;
    }

    public async Task<TResponse> Handle(TRequest request,
                                  RequestHandlerDelegate<TResponse> next,
                                  CancellationToken cancellationToken)
    {
       if (request.BypassCache)
           return await next();
       
       var cacheKey = $"{_cacheSettings.RedisInstanceName}:{request.CacheKey}";
       var cacheResponse = await _cache.GetAsync(cacheKey, cancellationToken);
       
       if (cacheResponse != null)
           return JsonSerializer.Deserialize<TResponse>(Encoding.UTF8.GetString(cacheResponse));

       var response = await next();
       if (response == null)
           return default;

       var options = new DistributedCacheEntryOptions
       {
           SlidingExpiration = request.SlidingExpiration, AbsoluteExpiration = DateTime.UtcNow.AddDays(1)
       };
       await _cache.SetAsync(cacheKey, JsonSerializer.SerializeToUtf8Bytes(response), options, cancellationToken);

       return response;
    }
}
