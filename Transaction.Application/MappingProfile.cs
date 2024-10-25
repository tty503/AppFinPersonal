using TransactionApplication.Responses;
using TransactionCore.Entities;
using AutoMapper;
namespace AccountApplication
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Transaction, TransactionResponse>();
        }
    }
}