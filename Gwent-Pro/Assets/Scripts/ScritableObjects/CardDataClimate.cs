using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Climate Info",menuName ="Card Data Climate")]
public class CardDataClimate : Card
{
    [SerializeField] private bool[] afectationZone;
    [SerializeField] private int afectation;
    //private bool isActivateClimate = false;
    public bool[] AfectationZone { get => afectationZone;}
    public int Afectation { get => afectation;}

    public void Effect()
    {

    }


}
