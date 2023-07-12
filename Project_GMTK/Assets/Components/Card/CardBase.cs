using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBase : ScriptableObject
{

    public string cardName;
    public Sprite cardSprite;
    [TextArea]public string cardDescription;

    public bool hasPermission;
    [ConditionalField(nameof(hasPermission))]public CardPermissionClass permission;

    public virtual void Act(BuildingBase building)
    {

    }
}

[System.Serializable]
public class CardPermissionClass
{
    public BuildingType targetType;
    public bool notAllow;
}


//zombies deal small damage. they attack in area. deal more damage per fella.
//demon deals half of the max health or 40
//swarm kill field but only farm.
//fraud deals 20 damage only to corporations but receive less uspsicion.
//bomb deal 80 damage and twice as much suspiscion.
//corrupt fella: gets attached to the target. deals a portion of the money damage till the ened of the game. not civilian.
//