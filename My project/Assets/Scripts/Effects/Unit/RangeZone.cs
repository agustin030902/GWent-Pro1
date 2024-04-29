using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeZone : MonoBehaviour
{
    private GameObject card;
    private GameObject table;
    private GameObject subBoard;
    private GameObject zoneUpdate;

    private void OnEnable()
    {
        card = transform.parent.gameObject;
        table = GameObject.Find("Table");

        if(table.transform.rotation.x == 0)
        {
            subBoard = GameObject.Find("SubBoardPalyer1");
        }
        else
        {
            subBoard = GameObject.Find("SubBoardPalyer1");
        }
        zoneUpdate = subBoard.transform.GetChild(2).gameObject;
        IncreaseCardsZone(zoneUpdate);

    }
    private void IncreaseCardsZone(GameObject zone)
    {
        GameObject card;
        CardController cardController;

        for(int i =0;i<zone.transform.childCount;i++)
        {
            card = zone.transform.GetChild(i).gameObject;
            cardController = card.GetComponent<CardController>();
            CardDataUnit unit = (CardDataUnit)cardController.infoCard;
            unit.Power ++;
        }

    }
}
