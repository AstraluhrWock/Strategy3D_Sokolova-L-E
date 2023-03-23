using UnityEngine;
using Utils;
using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem.CommandRealization
{
    public sealed class ProduceUnitCommand : IProduceUnitCommand
    {
        [InjectAsset("Chomper")] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;
    }
}