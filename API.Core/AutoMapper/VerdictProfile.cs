using AutoMapper;
using DTO.Verdict;

namespace API.Core.AutoMapper
{
    public class VerdictProfile : Profile
    {
        public VerdictProfile()
        {
            CreateMap<VerdictModel, VerdictDto>();
            CreateMap<VerdictDto, VerdictModel>();
        }
    }
}