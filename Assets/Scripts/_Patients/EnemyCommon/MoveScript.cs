using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private bool isMoving = true;
    private bool isIdle;
    public float speed;
    private Rigidbody2D m_Rigidbody2D;

    private Animator m_animator;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public bool Direction = true;

    // Start is called before the first frame update

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_animator.SetBool("Walking", isMoving);
    }

    void Update()
    {
        if (!isMoving && speed != 0)
            m_animator.SetBool("Walking", true);

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, new Vector2(transform.position.x + (Direction ? -speed : speed ), transform.position.y), ref velocity, smoothTime);
    }

    public void FixedUpdate()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + (Direction ? -4 : 4), transform.position.y), -Vector2.up,2);
        Debug.DrawRay(new Vector2(transform.position.x + (Direction ? -4 : 4), transform.position.y), -Vector2.up, Color.green);

        if (hit.collider == null) {         
            Direction = !Direction;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

    }






}
