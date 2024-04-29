using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Climate Info",menuName ="Card Data Climate")]
public class CardDataClimate : Card
{
    [SerializeField] private bool[] afectationZone;
    [SerializeField] private int afectation;
    private bool isActivateClimate = false;
    public bool[] AfectationZone { get => afectationZone;}
    public int Afectation { get => afectation;}
    public bool IsActivateClimate { get => isActivateClimate; set => isActivateClimate = value; }

    public void AfectionPowerCard(int countClimate, int zone)
    {
        GameObject board = GameObject.Find("Board");
        GameObject cards;
        CardController cardController;

        for (int i = 0;i<2 ;i++)
        {

            //for (int j = 1; j < 4; j++)
            //{
               // Debug.Log(board.transform.GetChild(i).GetChild(zone));

                for (int k = 0;k<board.transform.GetChild(i).GetChild(zone).childCount ;k++)
                {
                    cards = board.transform.GetChild(i).GetChild(zone).GetChild(k).gameObject;
                    cardController = cards.GetComponent<CardController>();
                    CardDataUnit unit = (CardDataUnit)cardController.infoCard;
                   // Debug.Log(unit.Type);

                    if (countClimate > cardController.ClimateModificatePower && unit.Type != "hero")
                    {
                        cardController.ClimateModificatePower++;
                        unit.Power += Afectation;
                    }
                }


            //}


        }

    }

}
