using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("Camera that will be used to follow the raycast")] [SerializeField] Camera fpsCamera;
    [Tooltip("Particle System for the gun's muzzle flash")] [SerializeField] ParticleSystem muzzleFlash;
    [Tooltip("Particle System for the bullet hitFX")] [SerializeField] GameObject hitEffect;

    [Header("Weapon Settings")]
    [Tooltip("The range of the weapon")] [SerializeField] float range = 100f;
    [Tooltip("The damage of the weapon")] [SerializeField] float damage = 4;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;

            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
}
