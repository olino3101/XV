using UnityEngine;
using UnityEngine.InputSystem;
public class CameraControler : MonoBehaviour
{
    private InputAction toggleCameraAction;
    public GameObject FirstPersonCamera;
    public GameObject ThirdPersonCamera;
    public GameObject Player;
    [SerializeField] private readonly float ThirdCamOffset = 8f;
    private float FirstCamHeight;

    public float turnThreshold = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toggleCameraAction = InputSystem.actions.FindAction("ToggleCameraView");
        UnityEngine.Debug.Log(toggleCameraAction);

        FirstCamHeight = FirstPersonCamera.transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        LookAround();
        ToggleCameraView();
    }
    
    void LookAround()
    {
        var mouse = Mouse.current;
        if (mouse == null)
        {
            Debug.Log("No mouse connected");
            return;
        }

        if (mouse.delta.ReadValue() != Vector2.zero)
        {
            Vector2 delta = mouse.delta.ReadValue() * 0.1f;

            GameObject currentCamera = FirstPersonCamera.activeSelf ? FirstPersonCamera : ThirdPersonCamera;
            currentCamera.transform.Rotate(-delta.y, delta.x, 0);
            Vector3 angles = currentCamera.transform.eulerAngles;
            angles.z = 0;
            currentCamera.transform.eulerAngles = angles;
        }

        if (mouse.position.ReadValue().x <= turnThreshold && Application.isFocused)
        {
            Player.transform.Rotate(0, -1f, 0);
        }
        else if (mouse.position.ReadValue().x >= Screen.width - turnThreshold && Application.isFocused)
        {
            Player.transform.Rotate(0, 1f, 0);
        }
    }
    void ToggleCameraView()
    {
        if (toggleCameraAction.WasPerformedThisFrame())
        {
            
            if (FirstPersonCamera.activeSelf)
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
    }

    public bool IsFirstPersonActive()
    {
        return FirstPersonCamera.activeSelf;
    }

    public float GetThirdPersonCameraAngle()
    {
        return ThirdPersonCamera.transform.eulerAngles.x;
    }

    public Vector3 GetActiveCameraForward()
    {
        return IsFirstPersonActive() ?
            FirstPersonCamera.transform.forward :
            ThirdPersonCamera.transform.forward;
    }

    public Vector3 GetActiveCameraRight()
    {
        return IsFirstPersonActive() ?
            FirstPersonCamera.transform.right :
            ThirdPersonCamera.transform.right;
    }
}
