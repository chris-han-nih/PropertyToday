namespace Application.Features.Properties.Commands;

using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

public class CreatePropertyRequest: IRequest<bool>
{
    public NewPropertyRequest PropertyRequest { get; set; }

    public CreatePropertyRequest(NewPropertyRequest propertyRequest) => PropertyRequest = propertyRequest;
}

public class CreatePropertyRequestHandler : IRequestHandler<CreatePropertyRequest, bool>
{
    private readonly IPropertyRepo _propertyRepo;
    private readonly IMapper _mapper;

    public CreatePropertyRequestHandler(IPropertyRepo propertyRepo, IMapper mapper)
    {
      _propertyRepo = propertyRepo;
      _mapper = mapper;
    } 
    
    public async Task<bool> Handle(CreatePropertyRequest request, CancellationToken cancellationToken)
    {
        var property = _mapper.Map<Property>(request.PropertyRequest);
        await _propertyRepo.AddNewAsync(property);
        
        return true;
    }
}
