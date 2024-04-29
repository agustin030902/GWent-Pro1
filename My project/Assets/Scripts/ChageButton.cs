using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChageButton : MonoBehaviour
{
    public GameObject Card;
    private Image imagePanel;
    private GameObject cardBlack;
    private GameObject handPlayer;
    private GameObject changeZone;
    private GameObject deckPlayer;
    private GameController gameController;
    private GameObject subBoard;
    private GameObject handPlayerActually;
    private GameObject table;
    private void OnEnable()
    {
        table = GameObject.Find("Table");
        GameObject board = GameObject.Find("Board");
        handPlayer = GameObject.Find("HandPlayer");
        changeZone = GameObject.Find("ChangeZone");
        gameController = board.GetComponent<GameController>();
        imagePanel = transform.parent.gameObject.GetComponent<Image>();

        int totalChildTable = table.transform.childCount - 1;
        if (table.transform.rotation.z == 0)
        {
            subBoard = GameObject.Find("SubBoardPlayer1");
            handPlayerActually = table.transform.GetChild(totalChildTable).gameObject;
        }
        else if (table.transform.rotation.z == 1)
        {
             subBoard = GameObject.Find("SubBoardPlayer2");
             handPlayerActually = table.transform.GetChild(totalChildTable-1).gameObject;
        }
        deckPlayer = subBoard.transform.GetChild(0).gameObject;
        for (int i = 0; 0 < handPlayerActually.transform.childCount;i++) 
        {
            handPlayerActually.transform.GetChild(0).SetParent(handPlayer.transform,true);
        }





    }

    public void ChangeCards()
    {
        GameObject selectedCard;
        //if (changeZone.transform.childCount != 0)
        //{
            int childCountDeck = deckPlayer.transform.childCount - 1;
            Destroy(deckPlayer.transform.GetChild(childCountDeck).gameObject);
            gameController.CardsSelected = changeZone.transform.childCount;

            for (int i = 0; i < changeZone.transform.childCount; i++)
            {
                selectedCard = changeZone.transform.GetChild(i).gameObject;
                GameObject cardInChangeZone = Instantiate(selectedCard,new Vector2(0,0),Quaternion.identity);
                cardInChangeZone.transform.SetParent(deckPlayer.transform,false);
                Destroy(selectedCard);
            }
            Card = Instantiate(Card,new Vector2(0,0),Quaternion.identity);
            Card.transform.SetParent(deckPlayer.transform, false);   
       //}
        imagePanel.enabled = false;



        for (int i = 0; i < gameObject.transform.parent.childCount ;i++)
        {
             gameObject.transform.parent.GetChild(i).gameObject.SetActive(false);   
        }

    }

    private void OnDisable()
    {
        for (int i = 0;0 < handPlayer.transform.childCount ; i++)
        {
            handPlayer.transform.GetChild(0).transform.SetParent(handPlayerActually.transform,false);
        }
        if(table.transform.rotation.z == 0)
        {
            gameController.InitializePlayer1 = true;
        }
        else if(table.transform.rotation.z == 1)
        {
            gameController.InitializePlayer21 = true;
            Destroy(transform.parent.gameObject);
        }

    }
}
