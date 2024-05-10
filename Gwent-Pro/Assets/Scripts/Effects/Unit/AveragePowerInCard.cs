using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AveragePowerInCard : MonoBehaviour
{
    private GameObject card;
    private CardController cardController;
    private CardDataUnit cardDataUnit;
    private GameObject board;
    private int maxPower = 0;
    private int totalCard = 0;
    private void OnEnable()
    {
        board = GameObject.Find("Board");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                for (int k = 0; k < board.transform.GetChild(i).GetChild(j).childCount; k++)
                {
                    card = board.transform.GetChild(i).GetChild(j).GetChild(k).gameObject;
                    cardController = card.GetComponent<CardController>();
                    cardDataUnit = (CardDataUnit)cardController.infoCard;
                    maxPower += cardDataUnit.Power;
                    totalCard++;
                }

            }

        }
        int average = maxPower / totalCard;


        card = transform.parent.gameObject;
        cardController = card.GetComponent<CardController>();
        cardDataUnit = (CardDataUnit)cardController.infoCard; cardDataUnit.Power = average;


    }

}
