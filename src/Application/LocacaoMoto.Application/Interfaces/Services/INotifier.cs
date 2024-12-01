using FluentValidation.Results;

namespace LocacaoMoto.Application.Interfaces.Services
{
    public interface INotifier
    {
        /// <summary>
        /// Adds a message to the notification list.
        /// </summary>
        /// <param name="message">The message to add.</param>
        void AddMessage(string message);
        void AddMessage(List<ValidationFailure> messages);

        /// <summary>
        /// Checks if there are any messages in the notification list.
        /// </summary>
        /// <returns>True if there are messages; otherwise, false.</returns>
        bool HasMessages();

        /// <summary>
        /// Retrieves all messages from the notification list.
        /// </summary>
        /// <returns>A list of messages.</returns>
        List<string> GetMessages();
    }
}
