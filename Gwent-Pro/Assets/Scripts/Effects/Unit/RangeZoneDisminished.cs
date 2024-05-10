using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeZoneDisminished : MonoBehaviour
{
    private GameObject table;
    private GameObject subBoard;
    private GameObject zoneUpdate;

    private void OnEnable()
    {
        table = GameObject.Find("Table");

        if (table.transform.rotation.z == 0)
        {
            subBoard = GameObject.Find("SubBoardPlayer1");
        }
        else
        {
            subBoard = GameObject.Find("SubBoardPlayer2");
        }
        zoneUpdate = subBoard.transform.GetChild(2).gameObject;
        DecreaseCardsZone(zoneUpdate);
    }
    private void DecreaseCardsZone(GameObject zone)
    {
        GameObject card;
        CardController cardController;

        for (int i = 0; i < zone.transform.childCount; i++)
        {
            card = zone.transform.GetChild(i).gameObject;
            cardController = card.GetComponent<CardController>();
            CardDataUnit unit = (CardDataUnit)cardController.infoCard;
            unit.Power--;
        }
    }
}
