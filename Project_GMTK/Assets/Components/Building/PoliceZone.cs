using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PoliceZone : ButtonBase
{

    bool isInArea;
    private void Update()
    {
        //

        if (isInArea)
        {
            PlayerHandler.instance.resource.ChangeSuspiscion(Time.deltaTime * 15);
        }
    }

    private void OnDisable()
    {
        isInArea = false;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);

        isInArea = true;
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        isInArea = false;
    }
}
