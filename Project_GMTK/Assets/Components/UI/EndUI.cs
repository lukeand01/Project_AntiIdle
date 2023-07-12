using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndUI : MonoBehaviour
{
    //
    [Separator("VICTORY")]
    [SerializeField] GameObject victoryHolder;
    public void VictoryUI()
    {
        victoryHolder.SetActive(true);
        defeatHolder.SetActive(false);

        PlayerHandler.instance.block.AddBlock("End", BlockClass.BlockType.Complete);

        Time.timeScale = 0;
    }

    [Separator("DEFEAT")]
    [SerializeField] GameObject defeatHolder;
    public void DefeatUI()
    {
        victoryHolder.SetActive(false);
        defeatHolder.SetActive(true);

        PlayerHandler.instance.block.AddBlock("End", BlockClass.BlockType.Complete);

        Time.timeScale = 0;
    }


    public void PlayAgain()
    {
        victoryHolder.SetActive(false);
        defeatHolder.SetActive(false);

        GameHandler.instance.StartGame();

    }

    public void QuitGame()
    {
        Application.Quit();
    }






}
