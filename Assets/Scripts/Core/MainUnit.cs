using UnityEngine;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;

public class MainUnit : CommandExecutorBase<ICommand>, ISelectable
{
    [SerializeField] private Transform _unitsParent;

    private float _health = 100;
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivot;

    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Transform PivotPoint => _pivot;

    public override void ExecuteSpecificCommand(ICommand command)
    {
        
    }
}
