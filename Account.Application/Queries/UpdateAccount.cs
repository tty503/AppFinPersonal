using HandlerException;
using MediatR;
using System.Net;

namespace AccountApplication.Queries
{
    public class UpdateAccount 
    {
        public class Run : IRequest<Unit>
        {
            public Guid Id { get; set; }
            public string? Name { get; set; }
            public decimal? Balance { get; set; }
            public string? Currency { get; set; }
        }
        public class Handler : IRequestHandler<Run, Unit>
        {
            private readonly AccountContext _context;
            public Handler(AccountContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Run request, CancellationToken cancellationToken)
            {
                var account = await _context.Accounts.FindAsync(request.Id);
                if(account == null)
                {
                    throw new HttpError(HttpStatusCode.NotFound, $"The account with {request.Id} not found");
                }
                account.Name = request.Name ?? account.Name;
                account.Balance = request.Balance ?? account.Balance;
                account.Currency = request.Currency ?? account.Currency;

                try
                {
                    var response = await _context.SaveChangesAsync();
                    if (response > 0)
                    {
                        return Unit.Value;
                    }

                    throw new HttpError(HttpStatusCode.BadRequest, "Error creating account. Please check the submitted data for any validation errors.");
                }
                catch (Exception ex)
                {
                    throw new HttpError(HttpStatusCode.InternalServerError, "An unexpected error occurred while creating the account.");
                }
            }
        }
    }
}
