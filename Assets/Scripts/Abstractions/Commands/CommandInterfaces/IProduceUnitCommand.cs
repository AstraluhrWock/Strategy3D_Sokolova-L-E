using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IProduceUnitCommand : ICommand, IIconHolder
    {
       public GameObject UnitPrefab { get; }
       float ProductionTime { get; }
       string UnitName { get; }
    }
}
