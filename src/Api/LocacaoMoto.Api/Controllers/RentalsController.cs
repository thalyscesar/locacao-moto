using LocacaoMoto.Api.Models;
using LocacaoMoto.Application.Commands;
using LocacaoMoto.Application.Interfaces.Services;
using LocacaoMoto.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoMoto.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly INotifier _notifier;
        private readonly IMediator _mediator;

        public RentalController(INotifier notifier, IMediator mediator)
        {
            _notifier = notifier;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateRental([FromBody] AddRentalCommand newRental)
        {
           var response = await _mediator.Send(newRental);

            if (_notifier.HasMessages())
                return BadRequest(new { mensagem = _notifier.GetMessages() });

            return CreatedAtAction(nameof(AddRentalCommand), new { response.Id });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRentalById(int id)
        {
            var response = await _mediator.Send(new GetRentalByIdQuery { Id = id });

            if (_notifier.HasMessages())
                return BadRequest(new { mensagem = _notifier.GetMessages() });

            if (response == null) return NotFound($"Rental with ID {id} not found.");

            return Ok(response);
        }

        [HttpPut("{id}/return")]
        public async Task<ActionResult> ReturnRental([FromBody] RentalReturnModel returnModel, int id )
        {
            var dailyRates = await _mediator.Send(new CalculateMottoRentalValueCommand() { ReturnDate = returnModel.ReturnDate, Id = id });

            if (_notifier.HasMessages())
                return BadRequest(new { mensagem = _notifier.GetMessages() });

            return Ok(dailyRates);
        }
    }
}
