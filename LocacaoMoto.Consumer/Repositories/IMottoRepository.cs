using LocacaoMoto.Consumer.Events;

namespace LocacaoMoto.Consumer.Repositories
{
    public interface IMottoRepository
    {
        Task Add(MottoCreatedEvent mottoCreated);
    }
}
