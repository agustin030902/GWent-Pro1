using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameCardEffect : MonoBehaviour
{
    private GameObject subBoard1;
    private GameObject subBoard2;
    private int card1Count;
    private int card2Count;
    private CardController cardController;
    private void OnEnable()
    {
        subBoard1 = GameObject.Find("SubBoardPlayer1");
        subBoard2 = GameObject.Find("SubBoardPlayer2");
        cardController = GetComponent<CardController>();
        CardDataUnit unit = (CardDataUnit)cardController.infoCard;

        card1Count = CardSameName(subBoard1,unit.Name);
        card2Count = CardSameName(subBoard2,unit.Name);

        unit.Power = card1Count+card2Count+unit.OriginPower;

    }
    private int CardSameName(GameObject subBoard,string name)
    {
        GameObject card;
        CardController cardController;

        int temp = 0;
        for (int i = 1; i <= 3; i++)
        {
            for (int j = 0; j < subBoard.transform.GetChild(i).childCount; j++)
            {
                card = subBoard.transform.GetChild(i).GetChild(j).gameObject;
                cardController = card.GetComponent<CardController>();
                CardDataUnit unit = (CardDataUnit)cardController.infoCard;
                if (unit.Name == name)
                {
                    temp++;
                }
            }
        }
        return temp;
    }
}
