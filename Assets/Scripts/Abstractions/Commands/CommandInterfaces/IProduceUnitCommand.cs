using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IProduceUnitCommand : ICommand
    {
       public GameObject UnitPrefab { get; }
    }
}
