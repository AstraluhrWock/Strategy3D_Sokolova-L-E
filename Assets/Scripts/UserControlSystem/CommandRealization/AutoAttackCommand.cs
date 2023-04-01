using Abstractions.Commands.CommandsInterfaces;
using Abstractions;

namespace UserControlSystem.CommandRealization
{

    public class AutoAttackCommand : IAttackCommand
    {
        public IAttackable Target { get; }
        public AutoAttackCommand(IAttackable target)
        {
            Target = target;
        }
    }
}