using MediatR;
using FluentValidation;
using AccountCore.Entities;
using HandlerException;
using System.Net;

namespace AccountApplication.Queries
{
    public class CreateAccount
    {
        public class Exec : IRequest<Unit>
        {
            public string Name { get; set; }
            public decimal Balance { get; set; }
            public string Currency { get; set; }
        }

        public class AccountValidator : AbstractValidator<Exec>
        {
            public AccountValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Balance).NotEmpty();
                RuleFor(x => x.Currency).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Exec, Unit>
        {
            private readonly AccountContext _context;
            public Handler(AccountContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Exec request, CancellationToken cancellationToken)
            {
                Guid GUID = Guid.NewGuid();
                var account = new Account
                {
                    Id = GUID,
                    Name = request.Name,
                    Balance = request.Balance,
                    Currency = request.Currency,
                };
                _context.Accounts.Add(account);
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
