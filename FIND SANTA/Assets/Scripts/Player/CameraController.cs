using Photon.Pun;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private float verticalMouse = 0, horizontalMouse = 0;

    private Animator CharacterAnimator;

    private GameObject mainCam;

    private void Start()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
           
            
            mainCam = transform.Find("Main Camera").gameObject;
            CharacterAnimator = GetComponent<Animator>();
            player = gameObject.transform.parent.gameObject;
            Debug.Log(player);
        }
        else
        {
            mainCam = transform.Find("Main Camera").gameObject;
            mainCam.SetActive(false);
        }
            
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
