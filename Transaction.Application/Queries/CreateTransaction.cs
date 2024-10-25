using MediatR;
using TransactionApplication.Responses;

namespace TransactionApplication.Queries
{
    public class CreateTransaction
    {
        public class Exec : IRequest<Unit>
        {

        }
        public class Handler : IRequestHandler<Exec, Unit>
        {
            public Task<Unit> Handle(Exec request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
