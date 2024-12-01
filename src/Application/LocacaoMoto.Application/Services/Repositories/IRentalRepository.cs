using LocacaoMoto.Application.Queries;
using LocacaoMoto.Application.Responses;
using LocacaoMoto.Domain.Entities;

namespace LocacaoMoto.Domain.Interfaces.Repositories
{
    public interface IRentalRepository
    {
        Task AddRental(Rental rental);
        Task<RentalResponse> GetRentalById(GetRentalByIdQuery getRentalByIdQuery);
        bool HasRentalMotto(GetRentalByMottoIdentifierQuery query);
        Task<RentalResponse> UpdateReturndDate(GetRentalByIdQuery getRentalByIdQuery);
    }
}
