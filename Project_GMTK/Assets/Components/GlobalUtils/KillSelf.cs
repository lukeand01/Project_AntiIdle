using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSelf : MonoBehaviour
{
    float current;
    float total;

    public void SetUp(float total)
    {
        current = 0;
        this.total = total; 
    }
    private void Update()
    {
        current += Time.deltaTime;

        if (current > total) Destroy(gameObject);
    }


}
