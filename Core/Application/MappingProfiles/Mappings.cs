namespace Application.MappingProfiles;

using Application.Features.Properties.Commands;
using Application.Models;
using AutoMapper;
using Domain;

public class Mappings: Profile
{
    public Mappings()
    {
        CreateMap<NewProperty, Property>();
        CreateMap<UpdatePropertyRequest, Property>();
    }
}
