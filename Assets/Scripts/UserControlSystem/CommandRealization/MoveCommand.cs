using UnityEngine;

using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem.CommandRealization
{
    public sealed class MoveCommand : IMoveCommand
    {
        public Vector3 Target { get; }

        public MoveCommand(Vector3 target)
        {
            Target = target;
        }
    }
}
