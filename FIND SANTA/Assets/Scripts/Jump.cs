using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Jump : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] string jumpAnimParameter = "isJumping";

    Animator anim; 
    
    Vector3 moveDirection;

    CharacterController controller;

    float gravity = -9.81f;

    private void Start()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            controller = GetComponent<CharacterController>();
            anim = GetComponent<Animator>();
        }
           
    }
    
    void Update()
    {
        if (GetComponent<PhotonView>().IsMine)
        {

            controller.Move(moveDirection * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
                DoJump();

            moveDirection.y += gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    void DoJump()
    {
        moveDirection.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);
        controller.Move(moveDirection * Time.deltaTime);
        anim.SetBool(jumpAnimParameter, true);
    }

    public void JumpFinish()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            anim.SetBool(jumpAnimParameter, false);
        }

    }
}
