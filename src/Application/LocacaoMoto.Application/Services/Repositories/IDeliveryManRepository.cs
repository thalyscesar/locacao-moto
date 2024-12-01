using LocacaoMoto.Application.Queries;
using LocacaoMoto.Domain.Entities;

namespace LocacaoMoto.Domain.Interfaces.Repositories
{
    public interface IDeliveryManRepository
    {
        Task AddDeliveryMan(DeliveryMan deliveryMan);
        bool HasCNHNumber(HasCNHNumberQuery query);
        bool HasCnpjNumber(HasCNPJQuery query);
        Task UpdatePathCnhImage(DeliveryMan deliveryMan);
        string GetCnhTypeByIdentifier(string identifier);
    }
}
