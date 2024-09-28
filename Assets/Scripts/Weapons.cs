using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float range = 100f;
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
        Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range);
        Debug.Log($"{hit.transform.name} Shot!");
    }
}
