using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Info", menuName = "Card Data Unit")]
public class CardDataUnit : Card
{
    [SerializeField] private string type;
    [SerializeField] private bool[] dropZone;
    [SerializeField] private int power;
    [SerializeField] private string faction;
    [SerializeField] private int originPower;
    //[SerializeField] private bool isLeaderProtected = false;
    private bool climateModificatePower = false;

    public CardDataUnit(string type, bool[] dropZone, int power, string faction, int originPower)
    {
        this.type = type;
        this.dropZone = dropZone;
        this.power = power;
        this.faction = faction;
        this.originPower = originPower;
    }

    public string Type { get => type; }
    public bool[] DropZone { get => dropZone; }
    internal int Power { get => power; set => power = value; }
    public string Faction { get => faction; }
    public int OriginPower { get => originPower; }
    public bool ClimateModificatePower {  get => climateModificatePower; set => climateModificatePower = value;}

    //public bool IsLeaderProtected { get => isLeaderProtected; set => isLeaderProtected = value; }
}
