using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;

namespace UserControlSystem.CommandRealization
{
    public sealed class AttackCommand : IAttackCommand
    {
        public GameObject Target { get; set; }
        public AttackCommand(IAttackable target)
        {
            //Target = target;
        }
    }
}
