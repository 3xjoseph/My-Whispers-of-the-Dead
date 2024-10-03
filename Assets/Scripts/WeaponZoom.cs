using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cvCamera;
    [SerializeField] float zoomOut = 60f;
    [SerializeField] float zoomIn = 30f;

    bool zoomedInToggle = false;

    void Update() 
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(!zoomedInToggle)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }    
    }
    void ZoomIn()
    {
        zoomedInToggle = true;
        cvCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = zoomIn;
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        cvCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = zoomOut;
    }
}
