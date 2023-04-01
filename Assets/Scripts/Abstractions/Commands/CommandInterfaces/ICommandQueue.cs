namespace Abstractions.Commands.CommandsInterfaces
{

    public interface ICommandsQueue
    {
        void EnqueueCommand(object command);
        void Clear();
        ICommand CurrentCommand { get; }
    }
}