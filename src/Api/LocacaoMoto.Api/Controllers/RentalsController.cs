using LocacaoMoto.Application.Commands;
using LocacaoMoto.Application.Interfaces.Services;
using LocacaoMoto.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoMoto.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly INotifier _notifier;

        public RentalController(INotifier notifier)
        {
            _notifier = notifier;
        }

        [HttpPost]
        public ActionResult<RentalResponse> CreateRental([FromBody] AddRentalCommand newRental)
        {
            if (_notifier.HasMessages())
                return BadRequest(new { mensagem = _notifier.GetMessages() });

            //if (newRental == null)
            //    return BadRequest("Invalid rental data.");

            //// Adiciona ID automaticamente
            //newRental.Id = rentals.Count > 0 ? rentals.Max(r => r.Id) + 1 : 1;
            //newRental.IsReturned = false;

            //rentals.Add(newRental);
            //return CreatedAtAction(nameof(GetRentalById), new { id = newRental.Id }, newRental);

            return Ok(null);
        }

        [HttpGet("{id}")]
        public ActionResult<RentalResponse> GetRentalById(int id)
        {
            if (_notifier.HasMessages())
                return BadRequest(new { mensagem = _notifier.GetMessages() });

            //var rental = rentals.FirstOrDefault(r => r.Id == id);
            //if (rental == null)
            //    return NotFound($"Rental with ID {id} not found.");
            //return Ok(rental);

            return Ok(null);
        }

        [HttpPut("{id}/devolution")]
        public ActionResult ReturnRental(int id)
        {
            if (_notifier.HasMessages())
                return BadRequest(new { mensagem = _notifier.GetMessages() });

            //var rental = rentals.FirstOrDefault(r => r.Id == id);
            //if (rental == null)
            //    return NotFound($"Rental with ID {id} not found.");

            //if (rental.IsReturned)
            //    return BadRequest("Rental has already been returned.");

            //rental.IsReturned = true;
            //rental.ReturnDate = System.DateTime.Now;

            //return Ok($"Rental ID {id} has been successfully returned.");
            return Ok(null);
        }
    }
}
