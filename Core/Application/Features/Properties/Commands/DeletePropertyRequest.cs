namespace Application.Features.Properties.Commands;

using Application.Repositories;
using MediatR;

public class DeletePropertyRequest: IRequest<bool>
{
    public int PropertyId { get; set; }

    public DeletePropertyRequest(int propertyId)
    {
        PropertyId = propertyId;
    }
}

public class DeletePropertyRequestHandler : IRequestHandler<DeletePropertyRequest, bool>
{
    private readonly IPropertyRepo _propertyRepo;

    public DeletePropertyRequestHandler(IPropertyRepo propertyRepo)
    {
        _propertyRepo = propertyRepo;
    }

    public async Task<bool> Handle(DeletePropertyRequest request, CancellationToken cancellationToken)
    {
        var property = await _propertyRepo.GetByIdAsync(request.PropertyId);
        if (property == null)
            return false;
        
        await _propertyRepo.DeleteAsync(property);
        return true;
    }
}
