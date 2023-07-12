using MyBox;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

    [HideInInspector]public SceneLoader loader;
    [HideInInspector]public Observer observer;

    [Separator("GRAPHIC REFERENCEE STUFF")]
    public GameObject explosionEffect;

    [Separator("BACKGROUND MUSIC")]
    [SerializeField] AudioClip gameBM;
    [SerializeField] AudioClip menuBM;

    [Separator("SFX")]
    public AudioClip destroySFX;
    public AudioClip damageSFX;

    AudioSource source;

    public event Action EventResetBuildings;
    public void OnResetBuildings() => EventResetBuildings?.Invoke();


    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);


        if (source == null) source = gameObject.AddComponent<AudioSource>();

        ChooseBackgroundMusic(0);

        DontDestroyOnLoad(gameObject);
        loader = GetComponent<SceneLoader>();
        observer = GetComponent<Observer>();
    }

    public void ChooseBackgroundMusic(int newScene)
    {
        //we choose when we eithre start the game or the background.

        source.Stop();

        if(newScene == 0)
        {
            source.clip = menuBM;
        }
        if(newScene == 1)
        {
            source.clip = gameBM;
        }

        source.Play();
    }

    public void StartGame()
    {
        //set valus back to thieir original.
        //destroy any cards flying arounds.
        //reset the positions of the gold clicker.
        //reset the negative gold clicker
        

        Time.timeScale = 1;
        OnResetBuildings();
        PlayerHandler.instance.resource.ResetValues();
        PlayerHandler.instance.ResetValue();
        PlayerHandler.instance.block.ClearBlock();
        UIHolder.instance.detective.ResetValue();
    }

    public void CreateSFX(AudioClip clip)
    {
        GameObject newObject = new GameObject();
        SFXUnit sfx = newObject.AddComponent<SFXUnit>();
        sfx.SetUp(clip);
    }

}
