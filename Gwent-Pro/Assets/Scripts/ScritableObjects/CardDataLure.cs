using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="info Lure",menuName ="CardDataLure")]
public class CardDataLure :Card
{
    [SerializeField] private int power = 0;
    public int Power { get => power;}
}
