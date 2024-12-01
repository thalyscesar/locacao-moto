using MediatR;

namespace LocacaoMoto.Application.Commands
{
    public class SendImageCNHCommand : IRequest
    {
        public string ContentyType { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public Stream Stream { get; set; }
    }
}
