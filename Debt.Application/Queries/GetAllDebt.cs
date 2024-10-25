using DebtCore.Entities;
namespace DebtApplication.Queries
{
    class GetAllDebt
    {
        public class Run : IRequest<List<Debt>>
        {
        }
        public class Handler : IRequestHandler<Run, List<Debt>>
        {
            private readonly DebtContext _context;
            private readonly IMapper _mapper;
            public Handler(DebtContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<DebtResponse>> Handle(Run request, CancellationToken cancellationToken)
            {
                var ListDebt = await _context.Accounts.ToListAsync();
                var response = _mapper.Map<List<Debt>, List<DebtResponse>>(ListDebt);
                return response;
            }
        }
    }
}
