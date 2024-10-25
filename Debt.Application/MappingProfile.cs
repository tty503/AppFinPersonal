using DebtCore.Entities;
using DebtApplication.Responses;
using AutoMapper;
namespace DebtApplication
{
    public class MappingProfile : Profile
    {
        CreateMap<Debt, DebtResponse>();
    }
}
