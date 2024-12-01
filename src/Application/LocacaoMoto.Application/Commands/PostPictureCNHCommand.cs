using MediatR;

namespace LocacaoMoto.Application.Commands
{
    public class PostPictureCNHCommand : IRequest
    {
        string PictureCNH { get; set; } = string.Empty;
    }
}
