using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandRealization;
using Abstractions;

namespace UserControlSystem
{
    public sealed class AttackCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>
    {
        protected override IAttackCommand CreateCommand(IAttackable argument)
            => new AttackCommand(argument);
    }
}
