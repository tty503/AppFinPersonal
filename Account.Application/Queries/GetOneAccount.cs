using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using AccountApplication.Responses;
using AccountCore.Entities;
using HandlerException;
using System.Net;

namespace AccountApplication.Queries
{
    public class GetOneAccount
    {
        public class Run : IRequest<AccountResponse> 
        { 
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Run, AccountResponse>
        {
            private readonly AccountContext _context;
            private readonly IMapper _mapper;
            public Handler(AccountContext context, IMapper mapper) 
            { 
                _context = context;
                _mapper  = mapper;
            }
            public async Task<AccountResponse> Handle(Run request, CancellationToken cancellationToken)
            {
                var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (account == null) 
                {
                    throw new HttpError(HttpStatusCode.NotFound, $"The account with ID : {request.Id} not found");
                }
                var response = _mapper.Map<Account, AccountResponse>(account);
                return response;
            }
        }
    }
}
