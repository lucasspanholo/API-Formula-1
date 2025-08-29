using API_Formula1.DTOs;
using API_Formula1.Models;
using AutoMapper;

namespace API_Formula1.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Driver, DriverDTO>().ReverseMap();
    }
}