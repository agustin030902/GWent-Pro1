using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDisminished : MonoBehaviour
{
    private GameObject card;
    private CardController cardController;
    private CardDataUnit cardDataUnit;
    private GameObject SubBoard;
    private GameObject table;
    private void OnEnable()
    {
        table = GameObject.Find("Table");
        SubBoard = table.transform.rotation.z == 0 ? GameObject.Find("SubBoardPlayer2"):GameObject.Find("SubBoardPlayer1");
        for (int j = 1; j < 4; j++)
        {
            for (int k = 0; k < SubBoard.transform.GetChild(j).childCount; k++)
            {
                 card = SubBoard.transform.GetChild(j).GetChild(k).gameObject;
                 cardController = card.GetComponent<CardController>();
                 cardDataUnit = (CardDataUnit)cardController.infoCard;
                 cardDataUnit.Power--;
            }
        }
    }
}
