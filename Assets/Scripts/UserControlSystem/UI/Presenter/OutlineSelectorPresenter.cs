using UnityEngine;
using Abstractions;
// using UserControlSystem;

public class OutlineSelectorPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectableValue;
    private OutlineSelector[] _outlineSelector;
    private ISelectable _currentSelectable;

    private void Start()
    {
        _selectableValue.OnSelected += OnSelected;
    }

    private void OnSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        SetSelected(_outlineSelector, false);
        _outlineSelector = null;

        if (selectable != null)
        {
            _outlineSelector = (selectable as Component).GetComponentsInParent<OutlineSelector>();
            SetSelected(_outlineSelector, true);
        }
        else
        {
            if (_outlineSelector != null)
            {
                SetSelected(_outlineSelector, false);
            }
        }

        _currentSelectable = selectable;

        static void SetSelected(OutlineSelector[] selectors, bool value)
        {
            if (selectors != null)
            {
                for (int i = 0; i < selectors.Length; i++)
                {
                    selectors[i].SetSelected(value);
                }
            }
        }
    }

}