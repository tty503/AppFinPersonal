using AccountApplication.Responses;
using AccountCore.Entities;
using AutoMapper;

namespace AccountApplication
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountResponse>();
        }
    }
}

