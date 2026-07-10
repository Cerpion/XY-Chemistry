using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Selector : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private InputSystem_Actions _input;

    private SelectedObject _currentObject;
    private SelectedObject _selectedItem;

    public Action<bool> OnPauseGame;
    private bool _isPaused;

    private void Awake()
    {
        _input = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _input.Player.Enable();
        _input.Player.Interact.started += OnPressStart;
        _input.Player.Interact.canceled += OnPressEnd;
        _input.Player.Pointer.performed += OnPointer;
        _input.Player.Pause.started += OnPause;
    }

    private void OnDisable()
    {
        _input.Player.Interact.started -= OnPressStart;
        _input.Player.Interact.canceled -= OnPressEnd;
        _input.Player.Pointer.performed -= OnPointer;
        _input.Player.Pause.started += OnPause;
        _input.Player.Disable();
    }
    private void OnPointer(InputAction.CallbackContext ctx)
    {
       
    }

    private void OnPause(InputAction.CallbackContext ctx)
    {
        _isPaused = !_isPaused;
        OnPauseGame?.Invoke(_isPaused);
    }

    public void RemovePause()
    {
        _isPaused = false;
    }

    private void Update()
    {
        if (_isPaused)
            return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();

        if (_selectedItem != null)
        {
            Vector3 screenPos = new Vector3(mousePosition.x, mousePosition.y, 16.27f);
            Vector3 worldPos = _camera.ScreenToWorldPoint(screenPos);

            _selectedItem.UpdateObject(worldPos);
            return;
        }


        Ray ray = _camera.ScreenPointToRay(mousePosition);

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

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.cadetBlue);

    }

    private void OnPressStart(InputAction.CallbackContext context)
    {
        if (_isPaused)
            return;

        if (_currentObject != null)
        {
            _selectedItem = _currentObject;
            _selectedItem.StartInteraction();

            _currentObject?.HoverExit();
            _currentObject = null;
        }
    }

    private void OnPressEnd(InputAction.CallbackContext context)
    {
        if (_isPaused)
            return;

        if (_selectedItem != null)
        {
            _selectedItem.EndInteraction();
            _selectedItem = null;
        }
    }

}
