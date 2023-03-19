using UnityEngine;
using Abstractions.Commands;
using Utils;

namespace UserControlSystem.CommandRealization
{
    public sealed class ProduceUnitCommand //: IProduceUnitCommand
    {
        [SerializeField] private GameObject _unitPrefab;
        [InjectAsset("Chomper")] private GameObject UnitPrefab => _unitPrefab;
    }
}