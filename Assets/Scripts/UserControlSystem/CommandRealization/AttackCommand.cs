using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Abstractions;

namespace UserControlSystem.CommandRealization
{
    public sealed class AttackCommand : IAttackCommand
    {
        public IAttackable Target { get; set; }
        public AttackCommand(IAttackable target)
        {
            Target = target;
        }
    }
}
