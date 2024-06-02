using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptClimateZone: MonoBehaviour
{
    private GameObject climateZone;
    private GameObject table;

    private void OnEnable()
    {
        climateZone = GameObject.Find("ClimateZone");
        table = GameObject.Find("Table");
    }
    private void Update()
    {
        for (int i = 0;i<climateZone.transform.childCount;i++)
        {
            if(table.transform.rotation.z == 1)
            {
                climateZone.transform.GetChild(i).rotation = Quaternion.Euler(0,0,180);   
            }
            else
            {
                climateZone.transform.GetChild(i).rotation = Quaternion.Euler(0,0,0);
            }

        }

    }

}