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

    public BoxCollider2D attackHand = null;

    // Update is called once per frame
    void Update()
    {
        if (isConnected) { 
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.F) && attackHand != null) {
            Debug.Log("Attacking!");
            attackHand.transform.position = new Vector2(attackHand.transform.position.x + 2, attackHand.transform.position.y);
        } else if (Input.GetKeyUp(KeyCode.F) && attackHand != null) {
            Debug.Log("Stop Attacking!");
            attackHand.transform.position = new Vector2(attackHand.transform.position.x - 2, attackHand.transform.position.y);
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
