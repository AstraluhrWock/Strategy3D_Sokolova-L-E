using UnityEngine;
using Abstractions;
using Abstractions.Commands.CommandsInterfaces;
using Abstractions.Commands;

public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable, IHealthHolder
{
    //[SerializeField] private GameObject _unitPrefab;
    [SerializeField] private Transform _unitsParent;
    [SerializeField] private Transform _pivot;

    private float _health = 1000;
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;

    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Transform PivotPoint => _pivot;


    
    public override void ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
    }
}