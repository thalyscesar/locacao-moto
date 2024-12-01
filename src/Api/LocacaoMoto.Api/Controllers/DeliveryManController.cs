using LocacaoMoto.Application.Commands;
using LocacaoMoto.Application.Interfaces.Services;
using LocacaoMoto.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LocacaoMoto.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryManController : ControllerBase
    {
        private readonly INotifier _notifier;
        private readonly IMediator _mediator;

        public DeliveryManController(INotifier notifier, IMediator mediator)
        {
            _notifier = notifier;
            _mediator = mediator;
        }

        [SwaggerOperation(
         Summary = "Create a new deliveryperon.")]
        [SwaggerResponse(201, "Rental created successfully.", typeof(DeliveryManResponse))]
        [SwaggerResponse(400, "Invalid rental data.", typeof(INotifier))]
        [HttpPost]
        public async Task<ActionResult<DeliveryManResponse>> Post([FromBody] AddDeliveryManCommand addDeliveryman)
        {

            var newDeliveryMan = await _mediator.Send(addDeliveryman);

            if (_notifier.HasMessages())
                return BadRequest(new { mensagem = _notifier.GetMessages() });

            return CreatedAtAction(nameof(AddDeliveryManCommand), new { Id = addDeliveryman.Identifier });
        }

        [SwaggerOperation(
       Summary = "Post picture CNH")]
        [SwaggerResponse(201, "Post picture created successfully.", typeof(DeliveryManResponse))]
        [SwaggerResponse(400, "Invalid rental data.", typeof(INotifier))]
        [HttpPost("{id}/cnh")]
        public async Task<ActionResult> UploadCNH(string id, IFormFile formFile)
        {

            await _mediator.Send(new SendImageCNHCommand() { Stream = formFile.OpenReadStream(), ContentyType = formFile.ContentType, Identifier = id });

            if (_notifier.HasMessages())
                return BadRequest(new { mensagem = _notifier.GetMessages() });

            return Ok();
        }
    }
}
