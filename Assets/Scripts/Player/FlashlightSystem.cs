using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float lightFade = .1f;
    [SerializeField] float angleFade = 1f; 
    [SerializeField] float minAngle = 10f;

    Light myLight;

    void Start() 
    {
        myLight = GetComponent<Light>();
    }

    void Update() 
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minAngle) { return; }
        else  myLight.spotAngle -= angleFade * Time.deltaTime; 
    }

    void DecreaseLightIntensity()
    {
        myLight.intensity -= lightFade * Time.deltaTime;
    }
}
