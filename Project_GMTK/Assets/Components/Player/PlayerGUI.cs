using MyBox;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour
{

    [SerializeField] Image reserveBar;
    public void UpdateReserve(float current)
    {
        reserveBar.fillAmount = current / 100;
    }
    [SerializeField] Image suspiscionBar;
    public void UpdateSuspiscion(float current)
    {
        suspiscionBar.fillAmount = current / 100;
    }

    [SerializeField] TextMeshProUGUI totalMoneyText;
    public void UpdateTotalMoney(float current)
    {
        totalMoneyText.text = current.ToString("F0");
    }

    [SerializeField] TextMeshProUGUI ownMoneyText;
    public void UpdateOwnMoney(float current)
    {
        ownMoneyText.text = current.ToString("F0");
    }


    [Separator("TIMER")]
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] Image timerImage;

    public void UpdateTimer(float current, float total)
    {
        timerText.text = current.ToString("F0");
        timerImage.fillAmount = current / total;
    }

}
