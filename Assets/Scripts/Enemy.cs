using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int baseAttack = 10;
    public int damage = 10; 
    public float attackRange = 1.0f;
    public float attackCooldown = 1.0f;
    public float chaseRange = 10.0f;
    public float moveSpeed = 3.0f;
    public Transform player;

    private bool isAttacking = false;

    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            transform.LookAt(player);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            if (!isAttacking)
            {
                StartCoroutine(Attack());
            }
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(baseAttack + damage); 
            }
        }

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
