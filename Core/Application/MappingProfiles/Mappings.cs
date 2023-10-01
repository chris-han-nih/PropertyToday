namespace Application.MappingProfiles;

using Application.Models;
using AutoMapper;
using Domain;

public class Mappings: Profile
{
    public Mappings()
    {
        CreateMap<NewPropertyRequest, Property>();
    }
}
