using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUI : MonoBehaviour
{
    //spawn 

    public GameObject[] spawnPos;
    public CardUnit unitTemplate;


    public CardBase[] cardBases;



    CardUnit hoveringCard;
    CardUnit draggingCard;

    float total = 5;
    float current;

    private void Awake()
    {
        total = 15;
        current = total;
    }

    private void Update()
    {
        if (Time.timeScale == 0) return;
        if (Input.GetMouseButton(0))
        {
            if (hoveringCard != null)
            {
                //then we start dragging and stop hovering
                hoveringCard.Drag();
                draggingCard = hoveringCard;
                hoveringCard = null;
            }
            if(draggingCard != null)
            {
                draggingCard.transform.position = Input.mousePosition;
            }
        }
        else
        {
            if(draggingCard != null)
            {
                //we do stuff if we ecan.

                BuildingBase building = PlayerHandler.instance.control.GetBuilding();
                

                //now we have to check it.
                if (building != null)
                {

                    if (draggingCard.cardBase.hasPermission)
                    {
                        if (draggingCard.cardBase.permission.notAllow)
                        {
                            if(draggingCard.cardBase.permission.targetType == building.data.buildingType)
                            {
                                draggingCard.Release();
                                hoveringCard = draggingCard;
                                draggingCard = null;
                                return;
                            }
                        }
                        else
                        {
                            if (draggingCard.cardBase.permission.targetType != building.data.buildingType)
                            {
                                draggingCard.Release();
                                hoveringCard = draggingCard;
                                draggingCard = null;
                                return;
                            }
                        }



                    }


                    draggingCard.cardBase.Act(building);
                    Destroy(draggingCard.gameObject);
                    draggingCard = null;
                    return;
                }



                //if i am hovering somthing theen we affect it.
                draggingCard.Release();
                hoveringCard = draggingCard;
                draggingCard = null;
            }
        }


        if(current > total)
        {

            SpawnUnit();
            current = 0;
            total = Random.Range(3, 6);
        }
        else
        {
            current += Time.deltaTime;
        }

    }

    public bool IsDraggingCard() => draggingCard != null;
    public void HoverCard(CardUnit card)
    {

        if(card == null)
        {
            hoveringCard = null;
            draggingCard = null;
            return;
        }

        if(hoveringCard != null)
        {
            //stop hovering         
        }

        hoveringCard = card;


    }

    public void ReceiveCard(CardUnit card)
    {
        if(card != null)
        {
            //then we deselect this card.
            //

        }
    }


    public void SpawnUnit()
    {
        //sometimes we roll twwo dices.
        int randomRoll = Random.Range(0, 10);
        int spawnTurns = 1;
        if(randomRoll > 7)
        {
            spawnTurns = 2;
        }


        GameObject lastSpawn = null;

        for (int i = 0; i < spawnTurns; i++)
        {
            CardBase card = cardBases[Random.Range(0, cardBases.Length)];
            CardUnit newObject = Instantiate(unitTemplate, Vector3.zero, Quaternion.identity);
            newObject.SetUp(card, this);
            newObject.transform.parent = transform;
            newObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);

            GameObject newSpawn = null;

            int brake = 0;

            while (newSpawn == null)
            {

                if(brake > 1000)
                {
                    Debug.Log("brake");
                    break;
                }

                GameObject pos = spawnPos[Random.Range(0, spawnPos.Length)];
                if(lastSpawn == null)
                {
                    lastSpawn = pos;
                    newSpawn = pos;
                }
                else
                {
                    if(pos != lastSpawn)
                    {
                        lastSpawn = pos;
                        newSpawn = pos;
                    }
                }


            }
            newObject.transform.position = newSpawn.transform.position;


        }

        
    }


}
