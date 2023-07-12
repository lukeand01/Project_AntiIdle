using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingBase : MonoBehaviour
{
    //types of building
    //stats of building

    //your building will produce cards. you can get thos ecards and drag to othr buildings to affeect theem.

    //the cards are about reducing something ina  building.

    //at eenough suspiscion othere things will be born that will search for the player.


    //protesting
    //zombies
    //demons
    //

    public  BuildingData data;
    GameObject graphic;

    [SerializeField] GameObject insuranceUI;
    [SerializeField] GameObject explosionEffect;

    //create a destruction effect.

    SpriteRenderer rend;

    [HideInInspector]public int totalHealth;
    [HideInInspector]public int currentHealth;

    public GameObject healthBar;
    public Image healthImage;


    public bool isDestroyed;
    public bool isProtected;

    public event Action EventAttacked;
    public void OnAttacked() => EventAttacked?.Invoke();

    public bool HasCorruption;
    public bool HasFire;


    //once you do that th buildings

    private void Awake()
    {
        graphic = transform.GetChild(0).gameObject;
        rend = graphic.GetComponent<SpriteRenderer>();

        totalHealth = data.initialHealth;
        currentHealth = totalHealth;

        healthBar.SetActive(false);
    }

    private void Start()
    {
        GameHandler.instance.EventResetBuildings += ResetValues;

        total = 5;
    }


    float current;
    float total;

    private void Update()
    {


        if(current >= total)
        {
            if (HasFire)
            {
                //deal damage

                TakeDamage(2, 0);
            }

            if (HasCorruption)
            {
                //loses money of thee thing
                PlayerHandler.instance.resource.ChangeMoneyTotal(data.moneyDamage / 10);
            }

              

            current = 0;
        }
        else
        {
            current += Time.deltaTime;
        }


        
    }


    public void TakeDamage(int damage, float suspiscionModfier = 1, float moneyDamageModifier = 1)
    {             
        currentHealth -= damage;

        healthBar.SetActive(true);
        healthImage.fillAmount = ((float)currentHealth / (float)totalHealth);

        if (currentHealth <=0)
        {
            //receive a bit less.
            graphic.SetActive(false);
            healthBar.SetActive(false);

            isDestroyed = true;
            HasFire = false;
            HasCorruption = false;


            PlayerHandler.instance.resource.ChangeSuspiscion(((float)damage * data.suspiscionPerHealth / 2) * suspiscionModfier);           
            PlayerHandler.instance.resource.AddLostProperty(2.5f);

            PlayerHandler.instance.resource.ChangeMoneyTotal(-data.moneyDamage * moneyDamageModifier);
            PlayerHandler.instance.resource.ChangeGoldReserve(-15);

            GameObject newObject = Instantiate(GameHandler.instance.explosionEffect, transform.position, Quaternion.identity);
            newObject.AddComponent<KillSelf>().SetUp(5);

            GameHandler.instance.CreateSFX(GameHandler.instance.destroySFX);

        }
        else
        {
            //receive suspiscion.
            PlayerHandler.instance.resource.ChangeSuspiscion(((float)damage * data.suspiscionPerHealth) * suspiscionModfier);

            GameHandler.instance.CreateSFX(GameHandler.instance.damageSFX);
        }

        OnAttacked();
    }

    public void Act()
    {
        //each building will decide what it does.
    }

    public virtual void ActUI()
    {
        //show in description this thing here.
        UIHolder.instance.descriptor.StartDescribe(this);
    }

    public void ResetValues()
    {
        //we reset its health and insurance.
        //we activate it again.
        totalHealth = data.initialHealth;
        currentHealth = totalHealth;

        graphic.SetActive(true);
        isDestroyed = false;

        healthBar.SetActive(false);

        HasFire = false;
        HasCorruption = false;
    }

    //building have health, suspiscion, 

}
