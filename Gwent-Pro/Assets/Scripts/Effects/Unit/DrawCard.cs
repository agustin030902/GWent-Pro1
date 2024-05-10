using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCard : MonoBehaviour
{
    private GameObject card;
    private GameObject deck;
    private GameObject table;
    private GameObject subBoard;
    private GameObject handPlayer;
    private void OnEnable()
    {
        table = GameObject.Find("Table");
        if(table.transform.rotation.z == 1)
        {
            subBoard = GameObject.Find("SubBoardPlayer2");
            handPlayer = GameObject.Find("Player2 Hand");
        }
        else
        {
            subBoard = GameObject.Find("SubBoardPlayer1");
            handPlayer = GameObject.Find("Player1 Hand");
        }

        deck = subBoard.transform.GetChild(0).gameObject;
        Invoke(nameof(DrawACard),0.35f);
    }
    
    private void DrawACard()
    {
        int indexCard = Random.Range(0,deck.transform.childCount-2);
        card = deck.transform.GetChild(indexCard).gameObject;
        if(transform.parent.name != "Cemetery" && handPlayer != null)
        {
            card.transform.SetParent(handPlayer.transform, false);
        }
    }

}
