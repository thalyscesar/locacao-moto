using LocacaoMoto.Domain.Entities;
using LocacaoMoto.Domain.Interfaces.Repositories;
using LocacaoMoto.Infrastructure.Mappers;
using System.Reflection;

namespace LocacaoMoto.Infrastructure.Repositories
{
    public class DeliveryManRepository: IDeliveryManRepository
    {
        public DeliveryManRepository()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new List<Assembly> { typeof(DeliveryManMap).Assembly });
        }

        public Task AddDeliveryMan(DeliveryMan deliveryMan)
        {
            throw new NotImplementedException();
        }

        public Task SendPictureCNH(DeliveryMan deliveryMan)
        {
            throw new NotImplementedException();
        }
    }
}
