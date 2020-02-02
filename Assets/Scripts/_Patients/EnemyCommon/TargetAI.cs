using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAI : MonoBehaviour
{

    public float speed;

    public Transform target;
    public float chaseRange;
    private bool isMoving = true;
    private bool isIdle;
    private Animator m_animator;


    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_animator.SetBool("Walking", isMoving);
    }

    void Update()
    {
        //chasing player

        //Get the distance to target to check if close enough to chase.
        float distanceToTarget = Vector2.Distance(transform.position, target.position);
        if(distanceToTarget < chaseRange)
        {
            #region Move and turn towards player
            //start player chase - turn and move towards player

            m_animator.SetBool("Attacking", true);

            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 8);
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            #endregion

            transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
