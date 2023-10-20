using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int baseAttack = 10;
    public float attackCooldown = 1.0f;
    public MeleeWeapon equippedMeleeWeapon; // Reference to the equipped melee weapon script.

    private bool isAttacking = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            if (equippedMeleeWeapon != null)
            {
                StartCoroutine(Attack());
            }
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;

        // Handle attack animation or effect here.

        // Calculate damage based on the base attack and equipped melee weapon.
        int damage = baseAttack;
        if (equippedMeleeWeapon != null)
        {
            damage += equippedMeleeWeapon.weaponDamage;
        }

        // You can add logic to deal damage to enemies here.

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
        // Handle player death here.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MeleeWeapon"))
        {
            if (equippedMeleeWeapon == null)
            {
                equippedMeleeWeapon = other.GetComponent<MeleeWeapon>();
                equippedMeleeWeapon.gameObject.SetActive(false);
            }
        }
        else if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (equippedMeleeWeapon != null)
            {
                int damage = baseAttack + equippedMeleeWeapon.weaponDamage;
                enemy.TakeDamage(damage);
            }
        }
    }

}
