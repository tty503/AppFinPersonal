using MediatR;

namespace TransactionApplication.Queries
{
    public class UpdateTransaction
    {
        public class Run : IRequest<Unit>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Run, Unit>
        {
            public Task<Unit> Handle(Run request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
