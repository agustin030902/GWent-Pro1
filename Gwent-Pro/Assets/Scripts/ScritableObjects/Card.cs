using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Card Info", menuName = "Card")]
public class Card : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private string typeCard;
    [SerializeField] public int IdCard { get; set; }
    public string Name { get ; set; }
    public string TypeCard { get => typeCard;}
}
