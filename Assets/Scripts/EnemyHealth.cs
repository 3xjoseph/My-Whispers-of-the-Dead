using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [Tooltip("The x amount of hits to kill the enemy")][SerializeField] float hitPoints = 20f;

    //Create a public method which reduces hit points by the amount of damage.
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if ( hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
