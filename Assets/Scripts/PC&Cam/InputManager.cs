using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public bool PlayerCanMove { get; private set; } = true;
    public bool CanLookAround { get; private set; } = true;
    public Vector2 Move { get; private set; }
    public float MoveUpDown { get; private set; }
    public Vector2 MousePosition { get; private set; }
    public Vector2 MouseDelta { get; private set; }
    public bool IsFirstPersonActive { get; private set; } = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (InputSystem.actions.FindAction("MoveUpDown").IsPressed())
        {
            MoveUpDown = InputSystem.actions.FindAction("MoveUpDown").ReadValue<float>();
        }
        else
        {
            MoveUpDown = 0f;
        }

        if (InputSystem.actions.FindAction("ToggleCameraView").WasPerformedThisFrame())
        {
            IsFirstPersonActive = !IsFirstPersonActive;
            // because in first person mode the player should always be able to move
            if (IsFirstPersonActive)
            {
                PlayerCanMove = true;

            }
            CanLookAround = !CanLookAround;
            CameraController cameraController = FindFirstObjectByType<CameraController>();
            cameraController?.ToggleCameraView();
        }

        if (InputSystem.actions.FindAction("TogglePlayerMovement").WasPerformedThisFrame() && !IsFirstPersonActive)
        {
            PlayerCanMove = !PlayerCanMove;
        }

        if (InputSystem.actions.FindAction("ToggleLookAround").WasPerformedThisFrame())
        {
            CanLookAround = !CanLookAround;
        }
        
        Move = InputSystem.actions.FindAction("Move").IsPressed() ? InputSystem.actions.FindAction("Move").ReadValue<Vector2>() : Vector2.zero;
        
        MouseDelta = Mouse.current.delta.ReadValue();
        MousePosition = Mouse.current.position.ReadValue();
    }
}
