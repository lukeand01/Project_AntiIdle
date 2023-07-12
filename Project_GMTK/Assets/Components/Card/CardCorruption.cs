using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card / Corruption")]
public class CardCorruption : CardBase
{

    public override void Act(BuildingBase building)
    {
        base.Act(building);

        building.HasCorruption = true;
    }
}
