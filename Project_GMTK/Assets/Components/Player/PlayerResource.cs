using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResource : MonoBehaviour
{
    PlayerHandler handler;

    public float suspiscion;
    public float goldReserve;
    public float goldReservePerTick;
    public float moneyTotal;
    public float moneyTotalPerTick;
    public float moneyOwn;


    float lostPropertyCost;
    //you start with a lot of moneye but you lose with time.
    //what is the player going to bee clicking?
    //
    private void Awake()
    {
        handler = GetComponent<PlayerHandler>();
    }

    private void Start()
    {
        UIHolder.instance.player.UpdateSuspiscion(suspiscion);
        UIHolder.instance.player.UpdateReserve(goldReserve);
        UIHolder.instance.player.UpdateTotalMoney(moneyTotal);
    }

    private void Update()
    {


        ChangeMoneyTotal(moneyTotalPerTick * Time.deltaTime);
        ChangeGoldReserve(goldReservePerTick * Time.deltaTime);      

        if(suspiscion > 0)
        {
            ChangeSuspiscion(-Time.deltaTime * 2.5f);
        }

    }


    public void ResetValues()
    {
        suspiscion = 0;
        ChangeSuspiscion(0);
        UIHolder.instance.player.UpdateSuspiscion(suspiscion);

        goldReserve = 0;
        UIHolder.instance.player.UpdateReserve(goldReserve);

        moneyTotal = 40000;
        UIHolder.instance.player.UpdateTotalMoney(moneyTotal);


        lostPropertyCost = 0;
    }

    public void ChangeSuspiscion(float change)
    {
        suspiscion += change;
        UIHolder.instance.player.UpdateSuspiscion(suspiscion);
        handler.OnChangedSuspiscion(suspiscion);

        if(suspiscion >= 100)
        {
            //game over.
            UIHolder.instance.end.DefeatUI();
        }
    }
    public void ChangeGoldReserve(float change)
    {
        goldReserve += change;
        goldReserve = Mathf.Clamp(goldReserve, 0, 100);

        if(goldReserve == 100)
        {
            //then we start increasing the value of thee gold with base 
            ChangeMoneyTotal((moneyTotalPerTick * 5 * Time.deltaTime));
        }


        UIHolder.instance.player.UpdateReserve(goldReserve);
    }
    public void ChangeMoneyTotal(float change)
    {

        float alteredChange = change * (lostPropertyCost * 0.01f);
        moneyTotal += change - alteredChange;

        UIHolder.instance.player.UpdateTotalMoney(moneyTotal);

        if(moneyTotal <= 0)
        {
            //won game.
            UIHolder.instance.end.VictoryUI();
        }
    }
    public void ChangeMoneyOwn(float change)
    {
        moneyOwn += change;
        UIHolder.instance.player.UpdateTotalMoney(moneyOwn);
    }

    public void AddLostProperty(float value)
    {
        lostPropertyCost += value;
    }
}
