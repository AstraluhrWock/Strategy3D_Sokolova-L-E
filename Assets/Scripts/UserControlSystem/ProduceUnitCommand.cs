using UnityEngine;
using Zenject;
using Abstractions.Commands.CommandsInterfaces;
using Utils;

namespace UserControlSystem
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        [Inject(Id = "Chomper")] public string UnitName { get; }
        [Inject(Id = "Chomper")] public Sprite Icon { get; }
        [Inject(Id = "Chomper")] public float ProductionTime { get; }
        [InjectAsset("Chomper")] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;
       
    }
}