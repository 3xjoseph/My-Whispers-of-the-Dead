using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] Canvas pauseGame;

    bool isEnabled = false;

    void Start() 
    {
        pauseGame.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isEnabled == false)
            {
                pauseGame.enabled = true;
                GetComponent<StarterAssets.FirstPersonController>().enabled = false;
                Time.timeScale = 0;
                FindObjectOfType<WeaponSwitcher>().enabled = false;
                FindObjectOfType<AudioListener>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                isEnabled = true;
            }
            else
            {
                pauseGame.enabled = false;
                GetComponent<StarterAssets.FirstPersonController>().enabled = true;
                Time.timeScale = 1;
                FindObjectOfType<WeaponSwitcher>().enabled = true;
                FindObjectOfType<AudioListener>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                isEnabled = false;
            }
            
        }
    }
}
