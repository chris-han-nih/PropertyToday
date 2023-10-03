namespace Application.Features.Properties.Queries;

using Application.Models;
using Application.PipelineBehaviors.Contracts;
using Application.Repositories;
using AutoMapper;
using FluentAssertions.Extensions;
using MediatR;

public class GetPropertyByIdRequest: IRequest<PropertyDto>, ICacheable
{

    public GetPropertyByIdRequest(int propertyId)
    {
        PropertyId = propertyId;
        CacheKey = $"GetPropertyById:{propertyId}";
    }

    public int PropertyId { get; }
    public string CacheKey { get; set; }
    public bool BypassCache { get; set; } = false;
    public TimeSpan SlidingExpiration { get; set; } = 5.Minutes();
}

public class GetPropertyByIdRequestHandler : IRequestHandler<GetPropertyByIdRequest, PropertyDto>
{
    private readonly IPropertyRepo _propertyRepo;
    private readonly IMapper _mapper;

    public GetPropertyByIdRequestHandler(IPropertyRepo propertyRepo, IMapper mapper)
    {
        _propertyRepo = propertyRepo;
        _mapper = mapper;
    }

    public async Task<PropertyDto> Handle(GetPropertyByIdRequest request, CancellationToken cancellationToken)
    {
        var property = await _propertyRepo.GetByIdAsync(request.PropertyId);
        return property == null
                   ? null
                   : _mapper.Map<PropertyDto>(property);
    }
}
