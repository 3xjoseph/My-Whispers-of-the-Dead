  using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Restarted");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exited the Game");
    }
}
