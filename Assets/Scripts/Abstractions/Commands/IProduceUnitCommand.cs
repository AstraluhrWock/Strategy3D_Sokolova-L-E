using UnityEngine;

namespace Abstractions.Commands
{
    public interface IProduceUnitCommand : ICommand
    {
        GameObject UnitPrefab { get; }
    }
}