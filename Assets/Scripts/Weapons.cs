using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 4;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log($"{hit.transform.name} Shot!");
            
            //TODO: add hit FX
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null) return;

            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }
}
