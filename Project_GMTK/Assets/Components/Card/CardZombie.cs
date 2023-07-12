using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card / Zombie")]
public class CardZombie : CardBase
{

    //it spreads to the buildings around.

    public override void Act(BuildingBase building)
    {
        base.Act(building);

        //shoot a raycast from thee first targete.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(building.transform.position, 0.5f);
        float additionalDamage = 10;
        float currentDamage = 0;

        List<BuildingBase> actualTargetList = new();

        foreach (var item in colliders)
        {
            BuildingBase foundBuilding = item.GetComponent<BuildingBase>();

            if (foundBuilding.isDestroyed) continue;

            currentDamage += additionalDamage;
            actualTargetList.Add(foundBuilding);
        }


        foreach (var item in actualTargetList)
        {
            item.TakeDamage((int)currentDamage, 0.2f);
        }


    }
}
