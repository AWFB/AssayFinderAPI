using AutoMapper;
using Entities.Models;
using Shared.DTOs;

namespace AssayFinder
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Laboratory, LaboratoryDTO>()
                .ForMember("FullAddress",
                opts => opts.MapFrom(x => string.Join(", ", x.Address, x.City, x.Country, x.Postcode)));

            CreateMap<Assay, AssayDTO>();

            CreateMap<LaboratoryForCreationDTO, Laboratory>();

            CreateMap<AssayForCreationDTO, Assay>();

            CreateMap<AssayForUpdateDTO, Assay>();
            CreateMap<AssayForUpdateDTO, Assay>().ReverseMap();
        }
    }
}
