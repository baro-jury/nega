using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float moveSpeed = 5.0f;
    public int baseAttack = 10;
    public int currentAttack;
    public float attackRange = 1.0f;
    public float attackCooldown = 1.0f;
    public Transform weaponTransform;
    public Weapon equippedWeapon;

    private bool isAttacking = false;

    void Start()
    {
        currentHealth = maxHealth;
        currentAttack = baseAttack;
    }

    void Update()
    {
        
        if (currentHealth <= 0)
        {
            Die();
            return;
        }

        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;

        if (equippedWeapon != null)
        {
            currentAttack = baseAttack + equippedWeapon.weaponDamage;
            equippedWeapon.Attack(currentAttack);
        }
        else
        {
            currentAttack = baseAttack;
        }

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MeleeWeapon") || other.CompareTag("RangedWeapon"))
        {
            Weapon weapon = other.GetComponent<Weapon>();

            if (equippedWeapon == null)
            {
                equippedWeapon = weapon;
                other.gameObject.SetActive(false);
            }
        }
        else if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            TakeDamage(enemy.damage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
       
    }

    void Die()
    {
        Debug.Log("Game over!");
    }
}
