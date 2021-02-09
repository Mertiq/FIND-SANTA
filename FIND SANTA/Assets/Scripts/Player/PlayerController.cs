using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : MonoBehaviour
{
    private Animator characterAnimator;

    private GameObject cam;

    bool isFreezing;

    void Start()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            characterAnimator = GetComponent<Animator>();

            cam = transform.GetChild(2).gameObject;
            Debug.Log(cam);
        }
            
    }


    private void Update()
    {
        if(GetComponent<PhotonView>().IsMine)
            GetComponent<CharacterMovement>().HandleMovement();

    }

    private void FixedUpdate()
    {
    }

    private void LateUpdate()
    {
        if (GetComponent<PhotonView>().IsMine)
            cam.GetComponent<CameraController>().handleCameraMovement();
    }
}