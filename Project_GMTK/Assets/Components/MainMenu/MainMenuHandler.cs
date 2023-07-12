using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    
    public void PlayGame()
    {
        GameHandler.instance.loader.ChangeScene(1, 0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
