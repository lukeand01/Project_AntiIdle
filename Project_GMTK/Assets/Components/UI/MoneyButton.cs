using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoneyButton : ButtonBase
{
    [Separator("GOLD BUTTON")]
    [SerializeField] float speed;
    [SerializeField] GameObject isMakingMoney;

    bool isMouseOver;
    private void Update()
    {
        //it keeps following th emouse but its much slower.
        transform.position = Vector3.MoveTowards(transform.position, Input.mousePosition, Time.deltaTime * speed);


        if (isMouseOver)
        {
            //then we start increasing the gold value.
            PlayerHandler.instance.resource.ChangeGoldReserve(Time.deltaTime * 35);
        }
    }

    //whilee you have hovering you are making money.

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        isMouseOver = true;
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        isMouseOver = false;
    }

}
