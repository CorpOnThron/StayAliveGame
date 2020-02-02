using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlatform : MonoBehaviour
{
    [SerializeField]
    private Vector3 velocity;

    private bool moving;
    Vector2 startPos;
    void Start()
    {
        startPos = transform.position;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            moving = true;
            collision.collider.transform.SetParent(transform);
        }   
    }
     void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            moving = false;
            collision.collider.transform.SetParent(null);
            
        }
    }
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (moving)
        {
            transform.position += (velocity * Time.deltaTime);
        }
       /* if (moving)
            transform.position = Vector2.MoveTowards(transform.position, startPos, 3f * Time.deltaTime);*/

    }
}
