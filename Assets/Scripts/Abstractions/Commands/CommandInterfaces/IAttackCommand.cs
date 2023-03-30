using UnityEngine;
//using Utils;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IAttackCommand : ICommand
    {
        public IAttackable Target { get; }
    }
}
