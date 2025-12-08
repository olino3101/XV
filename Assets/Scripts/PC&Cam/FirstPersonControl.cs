using UnityEngine;
using UnityEngine.InputSystem;
public class FirstPersonControl : MonoBehaviour
{
    private InputAction moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAction.WasPerformedThisFrame())
        {
            Vector2 movement = moveAction.ReadValue<Vector2>();
            transform.Translate(new Vector3(movement.x, 0, movement.y));
        }
    }

}
