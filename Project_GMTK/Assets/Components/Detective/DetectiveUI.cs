using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectiveUI : MonoBehaviour
{
    public GameObject[] pathingPos;
    public DetectiveUnit detectiveTemplate;

    List<DetectiveUnit> currentUnits = new();

    private void Start()
    {
        PlayerHandler.instance.EventChangedSuspiscion += ChangedSuspiscion;
    }

    public void ResetValue()
    {
        foreach (var item in currentUnits)
        {
            Destroy(item.gameObject);
        }

        currentUnits.Clear();
    }

    void ChangedSuspiscion(float value)
    {
        if(value >= 50 && currentUnits.Count == 0)
        {
            SpawnDetective(50);
        }
        
        if(value >= 70 && currentUnits.Count == 1)
        {
            SpawnDetective(70);
        }
       
        if(value >= 90 && currentUnits.Count == 2)
        {
            SpawnDetective(90);
        }
        
    }

    [ContextMenu("SpawnUnit")]
    void ForceSpawn()
    {
        SpawnDetective(50);
    }

    
    void SpawnDetective(float baseValue)
    {
        Vector3 pos = pathingPos[Random.Range(0, pathingPos.Length)].transform.position;
        DetectiveUnit newObject = Instantiate(detectiveTemplate, pos, Quaternion.identity);
        newObject.transform.parent = transform;
        newObject.SetUp(this);
        currentUnits.Add(newObject);
    }


    public void RemoveThisFella(DetectiveUnit unit)
    {
        currentUnits.Remove(unit);
        Destroy(unit.gameObject);
    }

    public GameObject GetNewPathingPos(GameObject current)
    {
        GameObject newPathing = null;

        int brakee = 0;

        if(current == null)
        {
            return pathingPos[Random.Range(0, pathingPos.Length)];
        }

        while(newPathing == null)
        {
            brakee++;
            if (brakee > 1000)
            {
                Debug.Log("broke it off");
                return null;
            }


            GameObject choice = pathingPos[Random.Range(0, pathingPos.Length)];

            if(choice.name != current.name)
            {
                newPathing = choice;
            }

        }

        return newPathing;
    }

}
