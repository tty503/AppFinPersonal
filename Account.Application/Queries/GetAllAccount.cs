using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using AccountApplication.Responses;
using AccountCore.Entities;
using HandlerException;
using System.Net;

namespace AccountApplication.Queries
{
    public class GetAllAccount
    {
        public class Run : IRequest<List<AccountResponse>>
        {
        }
        public class Handler : IRequestHandler<Run, List<AccountResponse>>
        {
            private readonly AccountContext _context;
            private readonly IMapper _mapper;
            public Handler(AccountContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<AccountResponse>> Handle(Run request, CancellationToken cancellationToken)
            {
                var ListAccount = await _context.Accounts.ToListAsync();
                var response = _mapper.Map<List<Account>, List<AccountResponse>>(ListAccount);
                return response;
            }
        }
    }
}
