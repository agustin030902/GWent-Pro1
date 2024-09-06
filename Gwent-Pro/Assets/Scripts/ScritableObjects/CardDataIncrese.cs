using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Increase Info",menuName ="Card Data Increase")]
public class CardDataIncrease : Card
{
    //[SerializeField] private new string name;
    //[SerializeField] private bool[] invocationZone; //para saber donde esta invocada
    [SerializeField] private int increase;

    public CardDataIncrease(int increase)
    {
        this.increase = increase;
    }

    //public  string Name { get => name; }
    //public bool[] InvocationZone { get => invocationZone;}
    public int Increase { get => increase;}
}
