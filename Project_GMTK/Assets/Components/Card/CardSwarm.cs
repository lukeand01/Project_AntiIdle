using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card / Swarm")]
public class CardSwarm : CardBase
{

    public override void Act(BuildingBase building)
    {
        base.Act(building);


        building.TakeDamage(building.data.initialHealth);
    }
}
