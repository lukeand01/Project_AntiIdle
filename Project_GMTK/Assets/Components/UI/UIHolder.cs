using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHolder : MonoBehaviour
{
    public static UIHolder instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public PlayerGUI player;
    public Descriptor descriptor;
    public DetectiveUI detective;
    public CardUI card;
    public PauseUI pause;
    public EndUI end;



}
