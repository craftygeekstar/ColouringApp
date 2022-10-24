using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    /* 
        This script contains all the functions required to use the Main Menu and buttons used to move between scenes.
    */
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
