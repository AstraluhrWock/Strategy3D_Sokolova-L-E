using UnityEngine;
//using Utils;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IAttackCommand : ICommand
    {
        public GameObject Target {get; set;}
        //public IAttackable Target { get; }
    }
}
