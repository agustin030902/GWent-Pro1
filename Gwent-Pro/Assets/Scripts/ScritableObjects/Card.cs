using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu (fileName = "Card Info",menuName ="Card")]
public class Card : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private string typeCard;
    public string Name { get => name; }
    public string TypeCard { get => typeCard;}
}
