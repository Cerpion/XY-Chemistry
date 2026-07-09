using UnityEngine;
using UnityEngine.InputSystem;

public class Selector : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private InputSystem_Actions _input;
    public bool Busy;

    private SelectedObject _currentObject;

    private void Awake()
    {
        _input = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _input.Player.Enable();
        _input.Player.Attack.performed += OnClick;
        _input.Player.Pointer.performed += OnPointer;
    }

    private void OnDisable()
    {
        _input.Player.Attack.performed -= OnClick;
        _input.Player.Pointer.performed -= OnPointer;
        _input.Player.Disable();
    }
    private void OnPointer(InputAction.CallbackContext ctx)
    {
        if (Busy)
            return;

        Vector2 position = ctx.ReadValue<Vector2>();

        Ray ray = _camera.ScreenPointToRay(position);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<SelectedObject>(out var item))
            {
                if (_currentObject == item)
                {
                    return;
                }

                _currentObject?.HoverExit();
                _currentObject = item;
                _currentObject.HoverEnter();
            }
        }
        else
        {
            _currentObject?.HoverExit();
            _currentObject = null;
        }

        Debug.Log(_currentObject);
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        if (Busy)
            return;

        if (_currentObject == null)
        {
            return;
        }

        if (_currentObject.BlocksInteraction)
        {
            Busy = true;
        }

        _currentObject?.HoverExit();
        _currentObject.StartInteraction();
        _currentObject.OnFinished += EndBusy;
    }

    private void EndBusy()
    {
        _currentObject.OnFinished -= EndBusy;
        _currentObject = null;
        Busy = false;
    }
}
