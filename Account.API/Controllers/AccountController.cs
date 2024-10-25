using Microsoft.AspNetCore.Mvc;

using CommonApi.Controllers;
using AccountApplication.Responses;
using AccountApplication.Queries;
using MediatR;
namespace AccountAPI.Controllers
{
    public class AccountController : MyControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<AccountResponse>>> GetAllAccount()
        {
            return await _mediator.Send(new GetAllAccount.Run());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountResponse>> GetOneAccount(Guid id)
        {
            return await _mediator.Send(new GetOneAccount.Run { Id = id });
        }

        // NOTA : Conflicto entre CreateAccount.Run y EditAccout.Run (posiblemente motivado al Request)

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateAccount(CreateAccount.Exec data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("id")]
        public async Task<ActionResult<Unit>> UpdateAccount(UpdateAccount.Run data, Guid id)
        {
            data.Id = id;
            return await _mediator.Send(data);
        }


        [HttpDelete]
        public async Task<ActionResult<Unit>> DeleteAccount(Guid id)
        {
            return await _mediator.Send(new DeleteAccount.Run { Id = id });
        }
    }
}
