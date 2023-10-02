namespace Application.MappingProfiles;

using Application.Models;
using AutoMapper;
using Domain;

public class Mappings: Profile
{
    public Mappings()
    {
        CreateMap<NewProperty, Property>();
        CreateMap<UpdateProperty, Property>();
        CreateMap<Property, PropertyDto>();
        CreateMap<NewImage, Image>();
        CreateMap<UpdateImage, Image>();
        CreateMap<Image, ImageDto>();
    }
}
