using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCardRound : MonoBehaviour
{
    GameObject table;
    GameObject card;
    CardController cardController;
    CardDataLeader dataLeader;
    List<GameObject> cards;
    GameObject subBoard;
    GameController gameController;
    GameObject board;
    
    private void OnEnable()
    {
        table = GameObject.Find("Table");
        card = transform.parent.gameObject;
        cardController = card.GetComponent<CardController>();
        dataLeader = (CardDataLeader)cardController.infoCard;
        subBoard = table.transform.rotation.z == 0 ? GameObject.Find("SubBoardPlayer1")  : GameObject.Find("SubBoardPlayer2");
        board = GameObject.Find("Board");
        gameController = board.GetComponent<GameController>();
    }

    private void Update()
    {
        
    }
}
