using UnityEngine;
using UnityEngine.InputSystem;
public class CameraController : MonoBehaviour
{
    public GameObject FirstPersonCamera;
    public GameObject ThirdPersonCamera;
    public GameObject Player;
    public float moveSpeed = 5f;
    public float mouveUpDownSpeed = 3f;
    [SerializeField] private readonly float ThirdCamOffset = 8f;
    private float FirstCamHeight;

    public float turnThreshold = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FirstCamHeight = FirstPersonCamera.transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance.CanLookAround)
            LookAround();
        if (InputManager.Instance.IsFirstPersonActive)
        FirstCamFollowPlayer();
        if (!InputManager.Instance.PlayerCanMove && !InputManager.Instance.IsFirstPersonActive)
            MoveThirdPersonCamera();
    }
    
    private void MoveThirdPersonCamera()
    {
        if (InputManager.Instance.MoveUpDown != 0f)
        {
            float upDownInput = InputManager.Instance.MoveUpDown * mouveUpDownSpeed * Time.deltaTime;

            transform.position += new Vector3(0, upDownInput, 0);
        }

        if ( InputManager.Instance.Move == Vector2.zero )
            return ;
        
        Vector3 camForward = ThirdPersonCamera.transform.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = ThirdPersonCamera.transform.right;    
        camRight.y = 0;
        camRight.Normalize();

        Vector2 adjustedInput = InputManager.Instance.Move * moveSpeed * Time.deltaTime;

        Vector3 move = camForward * adjustedInput.y + camRight * adjustedInput.x;

        transform.position += move;
    }
    void LookAround()
    {
        if (Mouse.current == null)
        {
            Debug.Log("No mouse connected");
            return;
        }

        if (InputManager.Instance.MouseDelta != Vector2.zero)
        {
            Vector2 delta = InputManager.Instance.MouseDelta * 0.1f;

            GameObject currentCamera =  InputManager.Instance.IsFirstPersonActive ? FirstPersonCamera : ThirdPersonCamera;
            currentCamera.transform.Rotate(-delta.y, delta.x, 0);
            Vector3 angles = currentCamera.transform.eulerAngles;
            angles.z = 0;
            currentCamera.transform.eulerAngles = angles;
        }

        if (InputManager.Instance.MousePosition.x <= turnThreshold && Application.isFocused)
        {
            Player.transform.Rotate(0, -1f, 0);
        }
        else if (InputManager.Instance.MousePosition.x >= Screen.width - turnThreshold && Application.isFocused)
        {
            Player.transform.Rotate(0, 1f, 0);
        }
    }
    public void ToggleCameraView()
    {
        if (InputManager.Instance.IsFirstPersonActive)
        {
            ThirdPersonCamera.transform.position = new Vector3(FirstPersonCamera.transform.position.x, ThirdCamOffset, FirstPersonCamera.transform.position.z );
        }
        else
        {
            FirstPersonCamera.transform.position = new Vector3(ThirdPersonCamera.transform.position.x, FirstCamHeight, ThirdPersonCamera.transform.position.z);
        }
        FirstPersonCamera.SetActive(!FirstPersonCamera.activeSelf);
        ThirdPersonCamera.SetActive(!ThirdPersonCamera.activeSelf);
    }


    public Vector3 GetFirstCameraForward()
    {
        return InputManager.Instance.IsFirstPersonActive ?
            FirstPersonCamera.transform.forward :
            ThirdPersonCamera.transform.forward;
    }

    public Vector3 GetFirstCameraRight()
    {
        return InputManager.Instance.IsFirstPersonActive ?
            FirstPersonCamera.transform.right :
            ThirdPersonCamera.transform.right;
    }

    private void FirstCamFollowPlayer()
    {
        Vector3 targetPosition = new Vector3(
            Player.transform.position.x,
            FirstCamHeight,
            Player.transform.position.z
        );
        FirstPersonCamera.transform.position = targetPosition;
    }
}
