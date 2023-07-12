using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectiveUnit : ButtonBase
{

    GameObject pathingPos;
    DetectiveUI handler;

    bool isHovering;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pathingPos.transform.position, Time.deltaTime * 80);

        if(Vector3.Distance(pathingPos.transform.position, transform.position) < 0.5f)
        {
            //then we ask for a newe position.
            GetNewPathingPos();
        }


        if (isHovering)
        {
            if (UIHolder.instance.card.IsDraggingCard())
            {
                PlayerHandler.instance.resource.ChangeSuspiscion(Time.deltaTime * 16f);
            }
            else
            {
                PlayerHandler.instance.resource.ChangeSuspiscion(Time.deltaTime * 12f);
            }
        }

    }

    public void SetUp(DetectiveUI handler)
    {
        this.handler = handler;
        pathingPos = handler.GetNewPathingPos(pathingPos);


    }

    float baseValue;
    public void CheckIfItShouldExit(float currentValue)
    {
        if(currentValue < baseValue)
        {
            handler.RemoveThisFella(this);
        }
    }

    public void GetNewPathingPos()
    {
        GameObject newPathing = handler.GetNewPathingPos(pathingPos);
        pathingPos = newPathing;
    }


    private void OnDisable()
    {
        isHovering = false;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);

        //we increase suspisions. more if carrying a card.
        isHovering = true;
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);

        isHovering = false;

    }

}
