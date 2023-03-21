using UnityEngine;
using Utils;
using Abstractions.Commands;

namespace UserControlSystem.CommandRealization
{
    public sealed class ProduceUnitCommand //: IProduceUnitCommand
    {
        [SerializeField] private GameObject _unitPrefab;
        [InjectAsset("Chomper")] private GameObject UnitPrefab => _unitPrefab;
    }
}