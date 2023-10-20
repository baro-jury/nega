using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private Rigidbody enemyRigidbody;
    public float moveSpeed = 3f;
    public int maxHealth = 100;
    public int currentHealth;
    public int baseAttack = 10;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyRigidbody = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        Vector3 playerDirection = (player.position - transform.position).normalized;
        enemyRigidbody.AddForce(playerDirection * moveSpeed);
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
