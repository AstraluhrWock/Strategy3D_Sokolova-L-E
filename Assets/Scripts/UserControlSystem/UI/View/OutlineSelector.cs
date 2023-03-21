using UnityEngine;

public sealed class OutlineSelector : MonoBehaviour
{
    [SerializeField] private Outline[] _outlineComponent;

    private bool _isSelectedCache;

    private void Start() => DisableOutline();

    public void SetSelected(bool isSelected)
    {
        if (isSelected == _isSelectedCache)
        {
            return;
        }

        if (isSelected)
        {
            EnableOutline();
        }
        else 
        {
            DisableOutline();
        }

        _isSelectedCache = isSelected;
    }
    private void EnableOutline()
    {
        for (int i = 0; i < _outlineComponent.Length; i++)
        {
            _outlineComponent[i].enabled = true;
        }
    }

    private void DisableOutline()
    {
        for (int i = 0; i < _outlineComponent.Length; i++)
        {
            _outlineComponent[i].enabled = false;
        }
    }

    
}
