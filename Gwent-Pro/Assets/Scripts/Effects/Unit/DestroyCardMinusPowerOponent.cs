using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCardMinusPowerOponent : MonoBehaviour
{
    private GameObject subBoard;
    private GameObject card;
    private CardController cardController;
    private GameObject table;
    private void OnEnable()
    {
        table = GameObject.Find("Table");

        if(table.transform.rotation.z == 1)
        {
            subBoard = GameObject.Find("SubBoardPlayer1");
        }
        else
        {
            subBoard = GameObject.Find("SubBoardPlayer2");
        }
        card = CardMinusPower(subBoard);
        print(card.name);
        Destroy(card);
    }
    private GameObject CardMinusPower(GameObject subBoard)
    {
        int temp = int.MaxValue;
        GameObject cardResult = null;

        for (int i = 1;i<3; i++)
        {
            for (int j = 0;j < subBoard.transform.GetChild(i).childCount;j++)
            {
                GameObject card = subBoard.transform.GetChild(i).GetChild(j).gameObject;
                cardController = card.GetComponent<CardController>();
                if (cardController.infoCard is CardDataUnit)
                {
                    CardDataUnit dataUnit = (CardDataUnit)cardController.infoCard;
                    if(dataUnit.Power < temp)
                    {
                        temp = dataUnit.Power;
                        cardResult = card;
                    }
                }
            }
        }
        return cardResult;
    }
}