using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card / Poverty")]
public class CardPoverty : CardBase
{
    public override void Act(BuildingBase building)
    {
        base.Act(building);

        building.TakeDamage(building.data.initialHealth, 1, 2.5f);
    }
}
