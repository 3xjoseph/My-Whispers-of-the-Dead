using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [Tooltip("The amount of damage the enemy generates")] [SerializeField] float damage = 5f; 

    [SerializeField] AudioSource hitSFX;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null) { return; }
        target.PlayerHit(damage);
        hitSFX.Play();
        target.GetComponent<DisplayDamage>().ShowDamageCanvas();
    }
}
