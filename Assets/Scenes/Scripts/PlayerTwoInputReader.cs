using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

[CreateAssetMenu(fileName = "PlayerTwoInputReader", menuName = "Scriptable Objects/PlayerTwoInputReader")]
public class PlayerTwoInputReader : ScriptableObject, IPlayerTwoActions
{
    public event Action<Vector2> OnMoveLeftRightEvent;
    public event Action<bool> OnJumpEvent;
    public event Action<bool> OnActionEvent;
    
    private InputSystem_Actions inputSystemActions;
    private void OnEnable()
    {
        
        if (inputSystemActions == null)
        {
            inputSystemActions = new InputSystem_Actions();
            inputSystemActions.PlayerTwo.SetCallbacks(this);
        }
        
        inputSystemActions.Enable();
    }

    private void OnDisable()
    {
        inputSystemActions.Disable();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        OnMoveLeftRightEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnActionEvent?.Invoke(true);
        }

        if (context.canceled)
        {
            OnActionEvent?.Invoke(false);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnJumpEvent?.Invoke(true);
        }

        if (context.canceled)
        {
            OnJumpEvent?.Invoke(false);
        }
    }
}
