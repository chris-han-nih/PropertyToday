namespace Application.Features.Properties.Queries;

using Application.Models;
using Application.Repositories;
using AutoMapper;
using MediatR;

public class GetPropertiesRequest: IRequest<List<PropertyDto>>
{
}

public class GetPropertiesRequestHandler : IRequestHandler<GetPropertiesRequest, List<PropertyDto>>
{
    private readonly IPropertyRepo _propertyRepo;
    private readonly IMapper _mapper;

    public GetPropertiesRequestHandler(IPropertyRepo propertyRepo, IMapper mapper)
    {
        _propertyRepo = propertyRepo;
        _mapper = mapper;
    }

    public async Task<List<PropertyDto>> Handle(GetPropertiesRequest request, CancellationToken cancellationToken)
    {
        var properties = await _propertyRepo.GetAllAsync();
        if (properties == null || !properties.Any())
            return null;
       
        var propertyDtos = _mapper.Map<List<PropertyDto>>(properties);
        return propertyDtos;
    }
}
