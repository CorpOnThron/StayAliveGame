using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BotController : MonoBehaviour
{
    public int speed; // false - right
    public bool rotation = true; //true - left

    private bool IsGrounded;
    private BoxCollider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = this.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {




    }

    void Jump()
    {

    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground") && IsGrounded != true) 
            IsGrounded = true;
    }

    void Flip()
    {

    }
}
