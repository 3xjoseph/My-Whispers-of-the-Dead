using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEditor.EditorTools;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("The camera that will zoom in and out")] [SerializeField] CinemachineVirtualCamera cvCamera;
    [Tooltip("Gets the Rotation Speed of the Player")] [SerializeField] FirstPersonController firstPersonController;

    [Header("Zoom Settings")]
    [Tooltip("FOV Distance when zoomed out")] [SerializeField] float zoomOut = 60f;
    [Tooltip("FOV Distance when zoomed in")] [SerializeField] float zoomIn = 30f;

    [Header("Zoom Sensitivity Settings")]
    [Tooltip("Mouse sensitivity when zoomed in")] [SerializeField] float zoomInSensitivity = .5f;
    [Tooltip("Mouse sensitivity when zoomed out")] [SerializeField] float zoomOutSensitivity = 1f;

    bool zoomedInToggle = false;

    void OnDisable() 
    {
        ZoomOut();
    }

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
    public void ZoomIn()
    {
        zoomedInToggle = true;
        cvCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = zoomIn;
        firstPersonController.RotationSpeed = zoomInSensitivity;
    }

    public void ZoomOut()
    {
        zoomedInToggle = false;
        cvCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = zoomOut;
        firstPersonController.RotationSpeed = zoomOutSensitivity;
    }
}
