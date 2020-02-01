using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public int AttackForce = 1;
    public BotController player;
    public PlayerHealth playerHealth;
    private Animator m_animator;
    public Animation attack;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null || playerHealth == null)
        {
            player = GameObject.Find("Player").GetComponent<BotController>();

            playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        }
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.gameObject.name);
        if (collision.collider.gameObject.CompareTag("Projectile")) Die();
        if (collision.collider.gameObject.name == "Player") DealDamage(collision.collider.gameObject.transform.position);
    }

    private void Die() 
    {
        Destroy(this.gameObject, 0.1f);
    }

    private void DealDamage(Vector3 pos) {


        m_animator.SetTrigger("AttackTrigger");

        playerHealth.GetHit(AttackForce);

        if (pos.x > transform.position.x)
        {
            Debug.Log("should fall back");
            player.MoveOnHit(4);
        }
        else if (pos.x < transform.position.x) {
            Debug.Log("should fall back");
            player.MoveOnHit(-4);
        }


        
    }
}
