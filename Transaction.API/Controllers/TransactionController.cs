using TransactionApplication.Queries;
using TransactionApplication.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CommonApi.Controllers;

namespace TransactionAPI.Controllers
{
    public class TransactionController : MyControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TransactionResponse>>> GetAllTransaction()
        {
            return await _mediator.Send(new GetAllTransaction.Run());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionResponse>> GetOneTransaction(Guid id)
        {
            return await _mediator.Send(new GetOneTransaction.Run { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateTransaction(CreateTransaction.Exec data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("id")]
        public async Task<ActionResult<Unit>> UpdateTransaction(UpdateTransaction.Run data, Guid id)
        {
            data.Id = id;
            return await _mediator.Send(data);
        }


        [HttpDelete]
        public async Task<ActionResult<Unit>> DeleteTransaction(Guid id)
        {
            return await _mediator.Send(new DeleteTransaction.Run { Id = id });
        }
    }
}
