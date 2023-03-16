using System;
using UnityEngine;
using Abstractions;

[CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
public class SelectableValue : ScriptableObject
{
    public ISelectable CurrentValue { get; private set; }
    public event Action<ISelectable> OnSelected;
    public void SetValue(ISelectable value)
    {
        CurrentValue = value;
        OnSelected?.Invoke(value);
    }
}