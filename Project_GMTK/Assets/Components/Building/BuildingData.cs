using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class BuildingData : ScriptableObject
{
    //
    public BuildingType buildingType;

    public string buildingName;
    public string description;

    public int initialHealth;
    public float suspiscionPerHealth = 0.25f;

    public float moneyDamage;

    public string suspiscionLevel;

}

public enum BuildingType
{
    Civilian,
    Industrial,
    Corporation,
    Farm,
}

//what changes the houses?
//some buildings are protected by ensurancee so destroying them only increasese the money.
//