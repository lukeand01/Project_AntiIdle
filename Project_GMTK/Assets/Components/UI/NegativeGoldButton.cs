using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NegativeGoldButton : MonoBehaviour
{
    //spawn at a position for a short while 

    [SerializeReference] float totalCooldown;
    float currentCooldown;

    [SerializeField]float totalTimer;
    float currentTimer;

    bool isActive;

    public Transform[] spawnPositions;
    [SerializeField] ButtonEvent negativeGoldButton;

    [SerializeField] Image timerImage;

    private void Update()
    {
        if (isActive)
        {
            if(currentTimer > 0)
            {
                currentTimer -= Time.deltaTime;
                timerImage.fillAmount = currentTimer / totalTimer;
            }
            else
            {
                isActive = false;
                currentCooldown = 0;
                negativeGoldButton.gameObject.SetActive(false);
            }

        }
        else
        {

            if(currentCooldown > totalCooldown)
            {
                currentTimer = totalTimer;
                isActive = true;
                negativeGoldButton.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
                negativeGoldButton.gameObject.SetActive(true);
            }
            else
            {
                currentCooldown += Time.deltaTime;
            }

        }

    }

    public void Act()
    {
        if (!isActive) return;

        currentTimer -= totalTimer / 10;

        //remove gold.
        PlayerHandler.instance.resource.ChangeGoldReserve(-8);
        PlayerHandler.instance.resource.ChangeMoneyTotal(-150);

        timerImage.fillAmount = currentTimer / totalTimer;

    }

}
