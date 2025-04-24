using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    public static GameInput Instance { get; private set; }

    public event EventHandler OnMove;

    InputManager inputManager;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }


        inputManager = new InputManager();

        inputManager.Unit.Enable();

        inputManager.Unit.Move.performed += Move_performed;

        Instance = this;
    }

    private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnMove?.Invoke(this, EventArgs.Empty);
    }

    
}
