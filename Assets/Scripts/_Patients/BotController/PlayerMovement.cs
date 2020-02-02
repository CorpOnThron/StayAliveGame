using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isConnected = false;
    public BotController controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool attack = false;
    public Animator animator;

    
    private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastPosition != gameObject.transform.position)
        {
            animator.SetBool("isWalking", true);
        }
        else {
            animator.SetBool("isWalking", false);
        }
        lastPosition = gameObject.transform.position;

        if (isConnected) { 
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isJumping", true);
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.F)) {
            Debug.Log("Attacking!");
                animator.SetBool("isAttacking", true);
                controller.Attack(true);
        } else if (Input.GetKeyUp(KeyCode.F)) {
            Debug.Log("Stop Attacking!");
                animator.SetBool("isAttacking",false);
                controller.Attack(false);
            }
        }


        //if (Input.GetButtonDown("Crouch"))
        //{
        //    crouch = true;
        //}
        //else if (Input.GetButtonUp("Crouch"))
        //{
        //    crouch = false;
        //}

    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
