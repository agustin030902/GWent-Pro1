using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Unit Info",menuName ="Card Data Unit")]
public class CardDataUnit : Card
{
    [SerializeField] private string type;
    [SerializeField] private bool[] dropZone;
    [SerializeField] private int power;
    [SerializeField] private string faction;
    [SerializeField] private int originPower;

    public string Type { get => type;}
    public bool[] DropZone { get => dropZone;}
    internal int Power { get => power;  set => power = value; }
    public string Faction { get => faction;}
    public int OriginPower { get => originPower;}
}
