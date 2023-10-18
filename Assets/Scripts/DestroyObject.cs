using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;

    private void Start()
    {
        currentHP = maxHP;
    }


    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            DestroyObject();
        }
    }


    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
