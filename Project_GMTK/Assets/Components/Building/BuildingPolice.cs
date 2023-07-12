using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPolice : BuildingBase
{
    [Separator("POLICE")]
    [SerializeField] GameObject zone;

    private void Start()
    {
        PlayerHandler.instance.EventChangedSuspiscion += ReceiveSuspiscion;
    }


    void ReceiveSuspiscion(float value)
    {
        if(value > 25)
        {
            //then wew increase 
            zone.SetActive(true);
        }
        else
        {
            zone.SetActive(false);
        }
    }
}
