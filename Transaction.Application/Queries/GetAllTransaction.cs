using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using TransactionApplication.Responses;

namespace TransactionApplication.Queries
{
    public class GetAllTransaction
    {
        public class Run : IRequest<List<TransactionResponse>>
        {
        }
        public class Handler : IRequestHandler<Run, List<TransactionResponse>>
        {
            private readonly TransactionContext _context;
            private readonly IMapper _mapper;
            public Handler(TransactionContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<TransactionResponse>> Handle(Run request, CancellationToken cancellationToken)
            {
                var ListTransaction = await _context.Transactions.ToListAsync();
                var response = _mapper.Map<List<TransactionCore.Entities.Transaction>, List<TransactionResponse>>(ListTransaction);
                return response;
            }
        }
    }
}
