namespace Application.Features.Properties.Commands;

using Application.Models;
using Application.Repositories;
using MediatR;

public class UpdatePropertyRequest: IRequest<bool>
{
    public UpdateProperty UpdateProperty { get; set; }
    
    public UpdatePropertyRequest(UpdateProperty updateProperty) => UpdateProperty = updateProperty;
}

public class UpdatePropertyRequestHandler : IRequestHandler<UpdatePropertyRequest, bool>
{
    private readonly IPropertyRepo _propertyRepo;

    public UpdatePropertyRequestHandler(IPropertyRepo propertyRepo) => _propertyRepo = propertyRepo;

    public async Task<bool> Handle(UpdatePropertyRequest request, CancellationToken cancellationToken)
    {
        var property = await _propertyRepo.GetByIdAsync(request.UpdateProperty.Id);
        if (property == null)
        {
            return false;
        }

        property.Name = request.UpdateProperty.Name;
        property.Louge = request.UpdateProperty.Louge;
        property.Dining = request.UpdateProperty.Dining;
        property.Rates = request.UpdateProperty.Rates;
        property.Bathrooms = request.UpdateProperty.Bathrooms;
        property.Bedrooms = request.UpdateProperty.Bedrooms;
        property.Description = request.UpdateProperty.Description;
        property.ErfSize = request.UpdateProperty.ErfSize;
        property.FloorSize = request.UpdateProperty.FloorSize;
        property.Kitchens = request.UpdateProperty.Kitchens;
        property.Levies = request.UpdateProperty.Levies;
        property.PetsAllowed = request.UpdateProperty.PetsAllowed;
        property.Price = request.UpdateProperty.Price;
        property.Type = request.UpdateProperty.Type;
           
        await _propertyRepo.UpdateAsync(property);
        return true;

    }
}
