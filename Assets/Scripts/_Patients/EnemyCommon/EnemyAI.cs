﻿using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

    // units per second
    public float speed;
    private bool movingRight = true;
    public float distance;

    public Transform groundDetection;


    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if (movingRight == true) {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    }
}