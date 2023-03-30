using System.Linq;
using UnityEngine;
using Abstractions;
using UI.Model;
using UnityEngine.EventSystems;
using UserControlSystem;
using Zenject;
using UniRx;

public class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectableValue;
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackablesRMB;
    [SerializeField] private Transform _groundTransform;

    private Plane _groundPlane;

    [Inject]
    private void Init()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);
        var nonBlockedByUiFramesStream = Observable.EveryUpdate().Where(_ => !_eventSystem.IsPointerOverGameObject());
        var leftClicksStream = nonBlockedByUiFramesStream.Where(_ => Input.GetMouseButtonDown(0));
        var rightClicksStream = nonBlockedByUiFramesStream.Where(_ => Input.GetMouseButtonDown(1));
        var lmbRays = leftClicksStream.Select(_ => _camera.ScreenPointToRay(Input.mousePosition));
        var rmbRays = rightClicksStream.Select(_ => _camera.ScreenPointToRay(Input.mousePosition));
        var lmbHitsStream = lmbRays.Select(ray => Physics.RaycastAll(ray));
        var rmbHitsStream = rmbRays.Select(ray => (ray, Physics.RaycastAll(ray)));

        lmbHitsStream.Subscribe(hits =>
        {
            if (weHit<ISelectable>(hits, out var selectable))
            {
                _selectableValue.SetValue(selectable);
            }
        });

        rmbHitsStream.Subscribe(data =>
        {
            var (ray, hits) = data;
            if (weHit<IAttackable>(hits, out var attackable))
            {
                _attackablesRMB.SetValue(attackable);
            }
            else if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }
        });
    }

    private bool weHit<T>(RaycastHit[] hits, out T result) where T : class
    {
        result = default;
        if (hits.Length == 0)
        {
            return false;
        }
        result = hits
            .Select(hit => hit.collider.GetComponentInParent<T>())
            .Where(c => c != null)
            .FirstOrDefault();
        return result != default;
    }
}

