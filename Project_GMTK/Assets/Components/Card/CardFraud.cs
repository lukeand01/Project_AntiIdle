using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card / Fraud")]
public class CardFraud : CardBase
{

    public override void Act(BuildingBase building)
    {
        base.Act(building);

        building.TakeDamage(20, 0.5f);
    }
}
