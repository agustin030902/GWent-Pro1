using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataBase", menuName = "DataBase")]
public class DataBase : ScriptableObject
{
    public List<GameObject> List { get; set; }

}