using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    //
    public static PlayerHandler instance;

    [HideInInspector]public PlayerResource resource;
    [HideInInspector] public PlayerControl control;

    [HideInInspector]public BlockClass block;

    float currentTimer;
    [SerializeField] float totalTimer;




    private void Awake()
    {
        instance = this;

        resource = GetComponent<PlayerResource>();
        control = GetComponent<PlayerControl>();

        block = new BlockClass();
        ResetValue();
    }


    public void ResetValue()
    {
        currentTimer = totalTimer;
    }

    private void Update()
    {
        if(currentTimer <= 0)
        {
            //the game ends.
            Debug.Log("the game nds heree");
            UIHolder.instance.end.DefeatUI();
        }
        else
        {
            currentTimer -= Time.deltaTime;
            UIHolder.instance.player.UpdateTimer(currentTimer, 120);
        }
    }


    //we 
    public event Action<float> EventChangedSuspiscion;
    public void OnChangedSuspiscion(float value) => EventChangedSuspiscion?.Invoke(value);


    //i will control the card here.
    [SerializeField] int maxInsurance;
    
    public void GetInsurance(BuildingBase building)
    {
        //wwe check if theree are eeenough.
    }

    
}
