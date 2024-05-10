using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LurePanelButton : MonoBehaviour
{
    GameObject table;
    GameObject subBoard;
    GameObject panelFather;
    GameObject sustitutionZone;
    GameObject selectionZone;
    GameObject playerHand;
    GameObject cardField;
    GameObject lureCard;
    CardController cardController;

    private void Start()
    {

        table = GameObject.Find("Table");

        subBoard = (table.transform.rotation.z == 1) ? GameObject.Find("SubBoardPlayer2") : GameObject.Find("SubBoardPlayer1");

        playerHand = (table.transform.rotation.z == 1) ? GameObject.Find("Player2 Hand") : GameObject.Find("Player1 Hand");

        panelFather = transform.parent.gameObject;

        selectionZone = panelFather.transform.GetChild(1).gameObject;

        sustitutionZone = panelFather.transform.GetChild(2).gameObject;

        lureCard = panelFather.transform.GetChild(4).gameObject;
        
        lureCard.SetActive(false);

        for (int i = 1; i < 4; i++)
        {
            for(int j = 0;j < subBoard.transform.GetChild(i).childCount ;j++)
            {
                cardField = subBoard.transform.GetChild(i).GetChild(j).gameObject;
                cardField.transform.SetParent(selectionZone.transform,false);
            }
        }
        
    }
    public void OnMouseDown()
    {
        bool[] zoneInvocation= new bool[3];
        GameObject cardSustitution = sustitutionZone.transform.GetChild(0).gameObject;
        if (sustitutionZone.transform.GetChild(0).gameObject.GetComponent<MonoBehaviour>() is not Image)
        {
            sustitutionZone.transform.GetChild(0).gameObject.GetComponent<MonoBehaviour>().enabled = false;
        }
        CardController cardController = cardSustitution.GetComponent<CardController>();
        CardDataUnit cardData = (CardDataUnit)cardController.infoCard;
        zoneInvocation = cardData.DropZone;
        sustitutionZone.transform.GetChild(0).SetParent(playerHand.transform,false);
        if (zoneInvocation[0])
        {
            lureCard.transform.SetParent(subBoard.transform.GetChild(1), false);
        }
        else if (zoneInvocation[1])
        {
            lureCard.transform.SetParent(subBoard.transform.GetChild(2), false);
        }
        else if (zoneInvocation[2])
        {
            lureCard.transform.SetParent(subBoard.transform.GetChild(3), false);
        }
        lureCard.SetActive(true);
        CardPlaces();
        Image imagePanel = panelFather.GetComponent<Image>();
        for (int i = 0; i < panelFather.transform.childCount; i++) 
        {
            panelFather.transform.GetChild(i).gameObject.SetActive(false);
        }
        imagePanel.enabled = false;
    }
    private void CardPlaces ()
    {
        MonoBehaviour effects;
        for (int i = 0; 0 < selectionZone.transform.childCount ; i++)
        {
            cardField = selectionZone.transform.GetChild(0).gameObject;
            cardController = cardField.GetComponent<CardController>();
            CardDataUnit unit = (CardDataUnit)cardController.infoCard;
            effects = cardField.GetComponent<MonoBehaviour>();
            if (effects is not Image)
            {
                effects.enabled = false;
            }
            if (unit.DropZone[0])
            {
                cardField.transform.SetParent(subBoard.transform.GetChild(1),false);
            }
            else if(unit.DropZone[1])
            {
                cardField.transform.SetParent(subBoard.transform.GetChild(2), false);
            }
            else if (unit.DropZone[2])
            {
                cardField.transform.SetParent(subBoard.transform.GetChild(3), false);
            }
        }

    }

}
