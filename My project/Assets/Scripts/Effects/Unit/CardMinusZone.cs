using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMinusZone : MonoBehaviour
{
    //private GameController gameController;
    private GameObject board;
    private GameObject subBoard1;
    private GameObject subBoard2;
    private GameObject cemetery1;
    private GameObject cemetery2;
    private int minusCard1;
    private int minusCard2;

    private void OnEnable()
    {
        GameObject MinusCardResult;
        board = GameObject.Find("Board");
        GameObject table = GameObject.Find("Table");
        subBoard1 = GameObject.Find("SubBoardPlayer1");
        subBoard2 = GameObject.Find("SubBoardPlayer2");
        cemetery1 = subBoard1.transform.GetChild(7).gameObject;
        cemetery2 = subBoard2.transform.GetChild(7).gameObject;

        if (CardMinus(subBoard1).transform.childCount < CardMinus(subBoard1).transform.childCount)
        {
            MinusCardResult = CardMinus(subBoard1);
            SendCardCementery(MinusCardResult, cemetery1);
        }
        else if(CardMinus(subBoard1).transform.childCount < CardMinus(subBoard1).transform.childCount)
        {
            MinusCardResult = CardMinus(subBoard2);
            SendCardCementery(MinusCardResult, cemetery2);

        }
        else
        {
            if(table.transform.rotation.x == 1)
            {
                MinusCardResult = CardMinus(subBoard1);
                SendCardCementery(MinusCardResult, cemetery1);

            }
            else
            {
                MinusCardResult = CardMinus(subBoard2);
                SendCardCementery(MinusCardResult, cemetery2);

            }
        }

    }

    private GameObject CardMinus(GameObject subBoard)
    {
        int minusCardTemp = int.MaxValue;
        GameObject cardMinus = new GameObject();
        for(int i = 1;i<=3 ;i++)
        {
            if(minusCard1 < subBoard.transform.GetChild(i).childCount)
            {
                cardMinus = subBoard.transform.GetChild(i).gameObject;  
                minusCardTemp = subBoard.transform.GetChild(i).childCount;
            }
        }
        return cardMinus;

    }

    private void SendCardCementery(GameObject cemetery,GameObject zone)
    {
        CardController cardController = new CardController();
        for(int i = 0; i < zone.transform.childCount;i++)
        {
            cardController = zone.transform.GetChild(i).gameObject.GetComponent<CardController>();
            CardDataUnit unit = (CardDataUnit)cardController.infoCard;
            GameObject card = zone.transform.GetChild(i).gameObject;
            if (!(unit.Type == "Hero"))
            {
                Instantiate(card, cemetery.transform);
                Destroy(card);
            }

        }

    }

}
