
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraControler : MonoBehaviour
{
    private InputAction toggleCameraAction;
    public GameObject FirstPersonCamera;
    public GameObject ThirdPersonCamera;
 
    [SerializeField] private readonly float ThirdCamOffset = 8f;
    private float FirstCamHeight;
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
}
