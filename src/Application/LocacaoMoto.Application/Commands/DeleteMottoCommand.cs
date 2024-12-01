using MediatR;

namespace LocacaoMoto.Application.Commands
{
    public class DeleteMottoCommand: IRequest
    {
        public DeleteMottoCommand(string identifier)
        {
            Identifier = identifier;
        }

        public string  Identifier { get; set; }
    }
}
