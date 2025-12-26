using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public CameraController cameraController;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (InputManager.Instance.PlayerCanMove == false || InputManager.Instance.Move == Vector2.zero)
            return ;

        Vector3 camForward = cameraController.GetFirstCameraForward();
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = cameraController.GetFirstCameraRight();    
        camRight.y = 0;
        camRight.Normalize();

        Vector2 adjustedInput = InputManager.Instance.Move * moveSpeed * Time.deltaTime;

        Vector3 move = camForward * adjustedInput.y + camRight * adjustedInput.x;

        transform.position += move;
    }
}
