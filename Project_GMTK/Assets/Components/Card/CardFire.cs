using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card / Fire")]
public class CardFire : CardBase
{

    //deals damage over time.
    public override void Act(BuildingBase building)
    {
        base.Act(building);

        PlayerHandler.instance.resource.ChangeSuspiscion(building.data.suspiscionPerHealth * (building.data.initialHealth / 3));
        building.HasFire = true;
    }

}
