using LocacaoMoto.Domain.Entities;

namespace LocacaoMoto.Domain.Interfaces.Repositories
{
    public interface IMottoRepository
    {
        Task AddMotto(Motto motto);
        Task<IEnumerable<Motto>> GetAllMottos();
        Task ModifyLicencePlateMotto(Motto motto);
        Task<Motto> GetMottoById(string identifier);
        Task DeleteMottoById(Motto motto);
        bool AnyLicencePlateAsync(string licensePlate);
        Task<Motto> GetMottoByLicensePlate(string licensePlate);
    }
}
