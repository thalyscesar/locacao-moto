using FluentValidation.Results;
using LocacaoMoto.Application.Interfaces.Services;

namespace LocacaoMoto.Application.Services
{
    public class Notifier : INotifier
    {
        private readonly List<string> messages = new List<string>();

        public void AddMessage(string message)
        {
            messages.Add(message);
        }

        public void AddMessage(List<ValidationFailure> errors)
        {
            string message = string.Join("\n", errors.Select(v => v.ErrorMessage));
            messages.Add(message);
        }

        public List<string> GetMessages()
        {
            return messages;
        }

        public bool HasMessages()
        {
            return messages.Any();
        }
    }
}
