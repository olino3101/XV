using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction moveUpDownAction;
    public float moveSpeed = 5f;
    public float mouveUpDownSpeed = 3f;
    public CameraControler cameraController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveUpDownAction = InputSystem.actions.FindAction("MoveUpDown");
    }

    // Update is called once per frame
    void Update()
    {
        if (!cameraController.IsFirstPersonActive() && moveUpDownAction.IsPressed())
        {
            float upDownInput = moveUpDownAction.ReadValue<float>() * mouveUpDownSpeed * Time.deltaTime;

            transform.position += new Vector3(0, upDownInput, 0);
        }


        if ( !moveAction.IsPressed())
            return ;

        Vector3 camForward = cameraController.GetActiveCameraForward();
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = cameraController.GetActiveCameraRight();    
        camRight.y = 0;
        camRight.Normalize();

        Vector2 input = moveAction.ReadValue<Vector2>() * moveSpeed * Time.deltaTime;

        Vector3 move = camForward * input.y + camRight * input.x;

        transform.position += move;   
    }
}
