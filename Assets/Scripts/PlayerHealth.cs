using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("The total amount of health the player has")][SerializeField] float health = 20f;

    public void PlayerHit(float damage)
    {
        health -= damage;
        if ( health <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
            Debug.Log("You Are Dead!");
        }
    }

}
