using UnityEngine;
using Abstractions;
using Abstractions.Commands;

public class MainUnit : CommandExecutorBase<ICommand>, ISelectable, IAttackable, IDamageDealer
{
    [SerializeField] private Transform _unitsParent;

    private float _health = 100;
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivot;
    [SerializeField] private int _damage;
    [SerializeField] private Animator _animator;
   // [SerializeField] private StopCommandExecutor _stopCommand;

    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Transform PivotPoint => _pivot;
    public int Damage => _damage;

    public override void ExecuteSpecificCommand(ICommand command)
    {
        
    }

    public void ReceiveDamage(int amount)
    {
        if (_health <= 0)
        {
            return;
        }
        _health -= amount;

        if (_health <= 0)
        {
            _animator.SetTrigger("PlayDead");
            Invoke(nameof(Destroy), 1f);
        }
    }

    private async void OnDestroy()
    {
        /*await _stopCommand.ExecuteSpecificCommand(new StopCommand());
        Destroy(gameObject);*/
    }
}
