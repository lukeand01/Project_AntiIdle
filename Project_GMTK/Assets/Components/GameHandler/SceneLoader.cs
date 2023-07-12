using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    //this is just to help the transition of the scene and starting the game.

    int currentScene;

    [SerializeField]GameObject loadingScreen;

    GameHandler handler;

    private void Awake()
    {
        handler = GetComponent<GameHandler>();
    }

    public void ChangeScene(int load, int unload)
    {
        StartCoroutine(ChangeSceneProcess(load, unload));
    }


    IEnumerator ChangeSceneProcess(int load, int unload)
    {
        loadingScreen.SetActive(true);
        
       
       AsyncOperation loadOperation = SceneManager.LoadSceneAsync(load, LoadSceneMode.Additive);
       

        while (!loadOperation.isDone)
        {
            yield return null;
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(load));
        SceneManager.UnloadSceneAsync(unload);

        currentScene = load;
        yield return new WaitForSeconds(0.5f);

        loadingScreen.SetActive(false);

        handler.ChooseBackgroundMusic(load);

    }

}
