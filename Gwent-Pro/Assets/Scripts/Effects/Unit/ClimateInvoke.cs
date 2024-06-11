using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimateInvoke : MonoBehaviour
{
    GameObject playerHand;
    GameObject table;
    CardController cardController;
    GameObject climateZone;
    GameObject card;
    private void OnEnable()
    {
        climateZone = GameObject.Find("ClimateZone");
        table = GameObject.Find("Table");
        playerHand = (table.transform.rotation.z == 0)? GameObject.Find("Player1 Hand") : GameObject.Find("Player2 Hand");
      
    }
    private void Start()
    {
        for (int j = 0; j < playerHand.transform.childCount; j++)
        {
            card = playerHand.transform.GetChild(j).gameObject;
            cardController = card.GetComponent<CardController>();
            if (cardController.infoCard is CardDataClimate)
            {
                card.transform.SetParent(climateZone.transform, false);
                break;
            }
        }
    }
}
