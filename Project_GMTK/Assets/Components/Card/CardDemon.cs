using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Card / Demon ")]
public class CardDemon : CardBase
{



    public override void Act(BuildingBase building)
    {
        base.Act(building);


        float halfHealthOfTarget = building.data.initialHealth / 2;
        float damage = 40;

        if(halfHealthOfTarget > damage)
        {
            building.TakeDamage((int)halfHealthOfTarget);
        }
        else
        {
            building.TakeDamage((int)damage);
        }

    }

}
