using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Descriptor : MonoBehaviour
{

    BuildingBase currentBuilding;


    GameObject holder;

    [SerializeField] Image descriptorIcon;
    [SerializeField] TextMeshProUGUI descriptorName;
    [SerializeField] TextMeshProUGUI descriptorDescription;
    [SerializeField] GameObject insurance;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI suspiscionText;
    [SerializeField] TextMeshProUGUI valueText;

    private void Awake()
    {
        holder = transform.GetChild(0).gameObject;
    }

    public void StartDescribe(BuildingBase building)
    {
        //
        holder.SetActive(true);
        building.EventAttacked += UpdateUI;
        currentBuilding = building;
        UpdateUI();
    }
    public void StopDescribe()
    {
        holder.SetActive(false);

        if(currentBuilding != null)
        {
            currentBuilding.EventAttacked -= UpdateUI;
            currentBuilding = null;
        }


    }

    void UpdateUI()
    {
        if(currentBuilding == null)
        {
            Debug.Log("this");
            return;
        }

        if(currentBuilding.data == null)
        {
            Debug.Log("that");
            return;
        }


        descriptorName.text = currentBuilding.data.buildingName;
        descriptorDescription.text = currentBuilding.data.description;

        suspiscionText.text = "Suspiscion " + currentBuilding.data.suspiscionLevel;
        healthText.text = "Health: " + currentBuilding.currentHealth.ToString() + " / " + currentBuilding.data.initialHealth.ToString();
        valueText.text = "Value " + currentBuilding.data.moneyDamage.ToString();


        insurance.SetActive(currentBuilding.isProtected);
    }

}

//describe
//get the cards working
//make it possible to put them in the stuff and the reaction.