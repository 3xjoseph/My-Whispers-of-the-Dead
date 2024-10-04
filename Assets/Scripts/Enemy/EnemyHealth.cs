using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [Tooltip("The x amount of hits to kill the enemy")] [SerializeField] float hitPoints = 20f;

    bool isDead = false;

    public bool IsDead() { return isDead; }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if ( hitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;
        
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
    }
}
