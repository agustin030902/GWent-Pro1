using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseScript : MonoBehaviour
{
    public DataBase DataBase;
    public static DataBaseScript data;
    void Start()
    {
        data = this;
        DataBase.List = new();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
