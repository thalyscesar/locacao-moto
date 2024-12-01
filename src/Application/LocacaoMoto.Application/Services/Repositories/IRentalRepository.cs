using LocacaoMoto.Application.Queries;
using LocacaoMoto.Application.Responses;
using LocacaoMoto.Domain.Entities;

namespace LocacaoMoto.Domain.Interfaces.Repositories
{
    public interface IRentalRepository
    {
        Task<int> AddRental(Rental rental);
        Task<Rental> GetRentalById(int id);
        bool HasRentalMotto(string identifier);
        Task UpdateReturndDate(Rental rental);
    }
}
