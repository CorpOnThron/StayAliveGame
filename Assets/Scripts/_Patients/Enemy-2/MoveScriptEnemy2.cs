using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptEnemy2 : MonoBehaviour
{
    private bool isMoving = true;
    private bool isIdle;
    public float speed;
    private Rigidbody2D rb;
    private Animator m_animator;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public bool Direction = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = RandomVector(-5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

        //if (!isMoving && speed != 0)
        //    m_animator.SetBool("Walking", true);

        // Smoothly move the camera towards that target position
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector2(transform.position.x + (Direction ? -speed : speed), transform.position.y), ref velocity, smoothTime);


    }

    private Vector3 RandomVector(float min, float max)
    {
        float x = Random.Range(min, max);
        float y = Random.Range(min, max);
        return new Vector2(x, y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground") rb.velocity = RandomVector(-5f, 5f);
    }
}
