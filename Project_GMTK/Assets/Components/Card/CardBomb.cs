using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card / Bomb")]
public class CardBomb : CardBase
{
    public override void Act(BuildingBase building)
    {
        base.Act(building);


        building.TakeDamage(80,1.5f); 
    }
}
