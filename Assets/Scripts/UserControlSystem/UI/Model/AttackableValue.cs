using UnityEngine;
using Abstractions;
using System;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Strategy Game/" + nameof(AttackableValue), order = 0)]
    public class AttackableValue : ScriptableObject
    {
        public IAttackable CurrentValue { get; private set; }
        public Action<IAttackable> OnSelected;

        public void SetValue(IAttackable value)
        {
            CurrentValue = value;
            OnSelected?.Invoke(value);
        }
    }
}