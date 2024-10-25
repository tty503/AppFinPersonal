using AutoMapper;
using HandlerException;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Transactions;
using TransactionApplication.Responses;
using TransactionCore.Entities;

namespace TransactionApplication.Queries
{
    public class GetOneTransaction
    {
        public class Run : IRequest<TransactionResponse>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Run, TransactionResponse>
        {
            private readonly TransactionContext _context;
            private readonly IMapper _mapper;
            public Handler(TransactionContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<TransactionResponse> Handle(Run request, CancellationToken cancellationToken)
            {
                var transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (transaction == null)
                {
                    throw new HttpError(HttpStatusCode.NotFound, $"The transaction with ID : {request.Id} not found");
                }
                    // se hace de forma explicita por conflicto con System.Transaction
                var response = _mapper.Map<TransactionCore.Entities.Transaction, TransactionResponse>(transaction);
                return response;
            }
        }
    }
}
