using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponDamage = 0; 
    public float attackRange = 1.0f;
    public LayerMask attackLayer;

    public void Attack(int damage)
    {
        if (CompareTag("MeleeWeapon"))
        {
            MeleeAttack(damage);
        }
        else if (CompareTag("RangedWeapon")) 
        {
            RangedAttack(damage);
        }
    }

    bool IsMeleeWeapon()
    {
        
        return attackRange < 2.0f;
    }

    void MeleeAttack(int damage)
    {
        

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange, attackLayer);
        foreach (var hitCollider in hitColliders)
        {
            
            if (hitCollider.CompareTag("Enemy"))
            {
                
                hitCollider.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }

    void RangedAttack(int damage)
    {
        
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, attackRange, attackLayer))
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }
}
