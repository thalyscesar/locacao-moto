using LocacaoMoto.Application.Queries;
using LocacaoMoto.Domain.Entities;

namespace LocacaoMoto.Domain.Interfaces.Repositories
{
    public interface IMottoRepository
    {
        Task AddMotto(Motto motto);
        Task<IEnumerable<Motto>> GetAllMottos();
        Task ModifyLicencePlateMotto(Motto motto);
        Task<Motto> GetMottoById(GetMottoByIdQuery getMottoByIdQuery);
        Task DeleteMottoById(Motto motto);
        bool AnyLicencePlateAsync(GetMottoByLicensePlateQuery motto);
    }
}
