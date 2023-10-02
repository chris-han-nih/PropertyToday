namespace Application.Features.Properties.Queries;

using Application.Models;
using Application.Repositories;
using AutoMapper;
using MediatR;

public class GetPropertyByIdRequest: IRequest<PropertyDto>
{
    public int PropertyId { get; set; }

    public GetPropertyByIdRequest(int propertyId)
    {
        PropertyId = propertyId;
    }
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
