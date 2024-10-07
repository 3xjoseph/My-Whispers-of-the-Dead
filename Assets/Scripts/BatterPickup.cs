using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterPickup : MonoBehaviour
{
    [SerializeField] float intensityReplenish = .5f;
    [SerializeField] float angleReplenish = 40f;

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashlightSystem>().RestoreLightAngle(angleReplenish);
            other.GetComponentInChildren<FlashlightSystem>().RestoreLightIntensity(intensityReplenish);
            Destroy(gameObject);
        }
    }
}
