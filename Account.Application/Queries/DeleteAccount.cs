using AccountCore.Entities;
using HandlerException;
using MediatR;
using System.Net;

namespace AccountApplication.Queries
{
    public class DeleteAccount
    {
        public class Run : IRequest<Unit>
        {
            public Guid Id { get; set; }
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
                    throw new HttpError(HttpStatusCode.NotFound, $"The account with ID : {request.Id} not found");
                }
                _context.Remove(account);
                try
                {
                    var response = await _context.SaveChangesAsync();
                    if (response > 0)
                    {
                        return Unit.Value;
                    }

                    throw new HttpError(HttpStatusCode.BadRequest, "Error delete account. Please check the submitted data for any validation errors.");
                }
                catch (Exception ex)
                {
                    throw new HttpError(HttpStatusCode.InternalServerError, "An unexpected error occurred while deleting the account.");
                }

            }
        }
    }
}
