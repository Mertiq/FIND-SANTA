using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player = null;

    private float verticalMouse = 0, horizontalMouse = 0;

    private Animator CharacterAnimator;

    private GameObject mainCam;

    private void Start()
    {
        mainCam = transform.Find("Main Camera").gameObject;
        CharacterAnimator = GetComponent<Animator>();
    }


    public void handleCameraMovement()
    {
        float[] cameraInputs = GetComponent<InputController>().GetCameraInputs();
        verticalMouse = cameraInputs[0];
        horizontalMouse = cameraInputs[1];

        transform.rotation = Quaternion.Euler(verticalMouse, horizontalMouse, player.transform.eulerAngles.z);
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }
}
