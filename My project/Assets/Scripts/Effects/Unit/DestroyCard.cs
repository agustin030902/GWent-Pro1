using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCard : MonoBehaviour
{
    private GameObject subBoard1;
    private GameObject subBoard2;
    private GameObject cemetery1;
    private GameObject cemetery2;
    private GameObject card1;
    private GameObject card2;
    private CardController cardController1;
    private CardController cardController2;
    private GameObject table;
    private void OnEnable()
    {
        GameObject cardResult;
        GameObject cemeteryResult;
        table = GameObject.Find("Table");


        subBoard1 = GameObject.Find("SubBoardPlayer1");
        subBoard2 = GameObject.Find("SubBoardPlayer2");

        cemetery1 = subBoard1.transform.GetChild(7).gameObject;
        cemetery2 = subBoard1.transform.GetChild(7).gameObject;

        card1 = CardMorePower(subBoard1);
        card2 = CardMorePower(subBoard2);
        cardController1 = card1.GetComponent<CardController>();
        cardController2 = card2.GetComponent<CardController>();

        CardDataUnit unit1 = (CardDataUnit)cardController1.infoCard;
        CardDataUnit unit2 = (CardDataUnit)cardController2.infoCard;



        if(unit1.Power > unit2.Power)
        {
            cardResult = card1;
            cemeteryResult = cemetery1;
        }
        else if (unit1.Power < unit2.Power)
        {
            cardResult = card2;
            cemeteryResult = cemetery2;
        }
        else
        {
            if(table.transform.rotation.x == 0)
            {
                cardResult = card2;
                cemeteryResult = cemetery2;
            }
            else { cardResult = card1;cemeteryResult = cemetery1;}
        }

        cardResult.transform.SetParent(cemeteryResult.transform, true);
    }
    private GameObject CardMorePower(GameObject subBoard)
    {
        GameObject card;
        CardController cardController;
        GameObject cardResult = new GameObject();

        int temp = int.MinValue;
        for (int i = 1; i <= 3; i++)
        {
            for (int j = 0; j < subBoard.transform.childCount ; j++)
            {
                 card = subBoard.transform.GetChild(i).gameObject;
                cardController = card.GetComponent<CardController>();
                CardDataUnit unit = (CardDataUnit)cardController.infoCard;
                if(unit.Power > temp)
                {
                    cardResult = card;
                    temp = unit.Power;
                }
            }
        }
        return cardResult;
    }
}
