using LocacaoMoto.Domain.Entities;

namespace LocacaoMoto.Domain.Interfaces.Repositories
{
    public interface IDeliveryManRepository
    {
        Task AddDeliveryMan(DeliveryMan deliveryMan);
        Task SendPictureCNH(DeliveryMan deliveryMan);
    }
}
