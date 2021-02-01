using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator characterAnimator;

    private GameObject cam;

    void Start()
    {
        characterAnimator = GetComponent<Animator>();
        cam = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        GetComponent<CharacterMovement>().HandleMovement();
    }

    private void FixedUpdate()
    {
    }

    private void LateUpdate()
    {
        cam.GetComponent<CameraController>().handleCameraMovement();
    }
}