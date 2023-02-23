using AutoMapper;
using Entities;
using EntitiesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaTriidy
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contry, ContryDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
        }
    }
}
