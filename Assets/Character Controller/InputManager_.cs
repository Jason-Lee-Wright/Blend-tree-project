using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, GamePlay.IPlayerActions
{
    private GamePlay gameplay;

    void Awake()
    {
        gameplay = new GamePlay();

        gameplay.Player.Enable();

        gameplay.Player.SetCallbacks(this);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.started || context.canceled || context.performed)
        {
            InputActions.MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started || context.canceled)
        {
            InputActions.InteractEvent.Invoke();
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started || context.canceled)
        {
            InputActions.SprintEvent.Invoke();
        }
    }
}



public static class InputActions
{
    public static Action<Vector2> MoveEvent;

    public static Action SprintEvent;

    public static Action InteractEvent;
}
