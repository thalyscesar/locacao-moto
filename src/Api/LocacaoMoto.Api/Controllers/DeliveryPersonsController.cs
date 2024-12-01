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
    public class DeliverymanController : ControllerBase
    {
        private readonly INotifier _notifier;
        private readonly IMediator mediator;

        public DeliverymanController(INotifier notifier)
        {
            _notifier = notifier;
        }

        [SwaggerOperation(
         Summary = "Create a new deliveryperon.")]
        [SwaggerResponse(201, "Rental created successfully.", typeof(DeliveryManResponse))]
        [SwaggerResponse(400, "Invalid rental data.", typeof(INotifier))]
        [HttpPost]
        public ActionResult<DeliveryManResponse> Post([FromBody] AddDeliveryManCommand addDeliveryman)
        {
            if (_notifier.HasMessages())
                return BadRequest( new { mensagem = _notifier.GetMessages() } );

            //deliveryPeople.Add(newDeliveryPerson);
            //return CreatedAtAction(nameof(AddDeliveryPerson), new { id = newDeliveryPerson.Id }, newDeliveryPerson);
            return Ok(null);
        }

        [SwaggerOperation(
       Summary = "Post picture CNH")]
        [SwaggerResponse(201, "Post picture created successfully.", typeof(DeliveryManResponse))]
        [SwaggerResponse(400, "Invalid rental data.", typeof(INotifier))]
        [HttpPost("{id}/cnh")]
        public ActionResult UploadCNH(int id, IFormFile cnhImage)
        {
            if (_notifier.HasMessages())
                return BadRequest(new { mensagem = _notifier.GetMessages() });

            //var deliveryPerson = deliveryPeople.FirstOrDefault(d => d.Id == id);
            //if (deliveryPerson == null)
            //    return NotFound($"Delivery person with ID {id} not found.");

            //if (cnhImage == null || cnhImage.Length == 0)
            //    return BadRequest("Invalid image file.");

            //// Simula o salvamento do arquivo (a lógica de salvar no servidor ou armazenamento externo seria implementada aqui)
            //var filePath = $"uploads/{cnhImage.FileName}"; // Exemplo fictício
            //deliveryPerson.CNHImagePath = filePath;

            //return Ok($"CNH image uploaded successfully for delivery person ID {id}.");

            return Ok(null);
        }
    }
}
