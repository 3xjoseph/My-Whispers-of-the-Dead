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
    [Tooltip("The getter for the ammo counter")] [SerializeField] Ammo ammoSlot;
    [Tooltip("The amount of time between fired shots")] [SerializeField] float timeBetweenShots = .5f;
    
    bool canShoot = true;
    
    void OnEnable() 
    {
        canShoot = true;
    }

    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0) && canShoot)
    //     {
    //         StartCoroutine(Shoot());  
    //     }
    // }

    // IEnumerator Shoot()
    // {
    //     canShoot = false;
    //     if (ammoSlot.GetCurrentAmmo() > 0)
    //     {
    //         PlayMuzzleFlash();
    //         ProcessRaycast();
    //         ammoSlot.ReduceCurrentAmmo();
    //     }
    //     yield return new WaitForSeconds(timeBetweenShots);  
    //     canShoot = true;
    // }

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
