using LocacaoMoto.Application.Commands;
using LocacaoMoto.Application.Interfaces.Services;
using LocacaoMoto.Application.Queries;
using LocacaoMoto.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoMoto.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MottosController : ControllerBase
    {

        private readonly INotifier _notifier;
        private readonly IMediator _mediator;

        public MottosController(INotifier notifier, IMediator mediator)
        {
            _notifier = notifier;
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MottoResponse>>> Get()
        {
            var response = await _mediator.Send(new GetAllQuery());

            if (_notifier.HasMessages())
                return BadRequest(new { mensagem = _notifier.GetMessages() });

            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var response = await _mediator.Send(new GetMottoByIdQuery(id));

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("{licensePlate}/plate")]
        public async Task<ActionResult> GetByLicensePlate(string licensePlate)
        {
            var response = await _mediator.Send(new GetMottoByLicensePlateQuery(licensePlate));

            if (response == null)
                return NotFound();

            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddMottoCommand newMotto)
        {
            var response = await _mediator.Send(newMotto);

            if (_notifier.HasMessages())
                return BadRequest(new { mensagem = _notifier.GetMessages() });

            return CreatedAtAction(nameof(Post), new { id = response.Identifier }, response);
        }


        [HttpPut("{id}/placa")]
        public async Task<ActionResult> Put(string id, [FromBody] string licensePlate)
        {
            var message = await _mediator.Send(new ModifyPlateMottoPlateCommand() { LicensePlate = licensePlate, Identifier = id });

            if (_notifier.HasMessages())
                return BadRequest(new { mensagem = _notifier.GetMessages() });

            return Ok(new { message = message });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteMottoCommand(id));

            if (_notifier.HasMessages())
                return BadRequest(new { mensagem = _notifier.GetMessages() });

            return Ok();
        }
    }
}
