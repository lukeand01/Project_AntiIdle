using MyBox;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardUnit : ButtonBase
{
    //it slowly goes down. it destroy itslef after quite a while.

    public CardBase cardBase;
    CardUI handler;

    Image mainImage;

    [Separator("CARD UNIT")]
    [SerializeField] Image backgroundImage;
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TextMeshProUGUI allowText;


    float duration = 50;
    float currentDuration;

    bool isDragging;
    float speed = 1;

    public void SetUp(CardBase cardBase, CardUI handler)
    {
        mainImage = GetComponent<Image>();
        this.cardBase = cardBase;
        this.handler = handler;

        UpdatUI();

        GameHandler.instance.EventResetBuildings += DestroyThis;
    }

    [SerializeField] Color onlyAllowColor;
    [SerializeField] Color notAllowColor;

    void DestroyThis()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameHandler.instance.EventResetBuildings -= DestroyThis;
    }

    void UpdatUI()
    {

        titleText.text = cardBase.cardName;
        descriptionText.text = cardBase.cardDescription;
        icon.sprite = cardBase.cardSprite;

        if (cardBase.hasPermission)
        {
            allowText.gameObject.SetActive(true);
            if (cardBase.permission.notAllow)
            {
                allowText.text = "Not Allow " + cardBase.permission.targetType.ToString();
                allowText.color = notAllowColor;
            }
            else
            {
                allowText.text = "Only Allow " + cardBase.permission.targetType.ToString();
                allowText.color = onlyAllowColor;
            }
        }
        else
        {
            allowText.gameObject.SetActive(false);
        }
                  

    }

    private void Update()
    {
        if (isDragging) return;
        transform.position -= Vector3.up * Time.deltaTime * 100 * speed;


    }

    
    public void Drag()
    {
        isDragging = true;
    }
    public void Release()
    {
        isDragging = false;
        speed = 2;
    }

    public void HoverOverBuilding()
    {

    }
    

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);

        handler.HoverCard(this);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);

        handler.HoverCard(null);

    }




}
