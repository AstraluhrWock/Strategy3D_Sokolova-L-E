using System.Linq;
using UnityEngine;
using Abstractions;
using UI.Model;

public class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectableValue;
    private void Update()
    {
        if (!Input.GetMouseButtonUp(0))
        {
            return;
        }

        var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));

        if (hits.Length == 0)
        {
            return;
        }

        var selectable = hits.Select(hit => hit.collider.GetComponentInParent<ISelectable>()).Where(c => c != null).FirstOrDefault();

        _selectableValue.SetValue(selectable);
    }
}
