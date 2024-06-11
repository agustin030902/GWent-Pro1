using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InvokeButton : MonoBehaviour
{
    private GameController gameController;
    private CardController cardController;
    private GameObject card;
    private GameObject panelInfoCardHand;
    private GameObject effectActivatePanel;
    private GameObject table;
    private Sprite spriteCard;
    private Image imagePanelCard;
    private MonoBehaviour cardEffect;
    private GameObject increasePanel;
    private Image imageIncreasePanel;
    private GameObject board;
    private GameObject lurePanel;
    private Image imageLurePanel;
    
    private void OnEnable()
    {
        table = GameObject.Find("Table");
        gameController = GameObject.Find("Board").GetComponent<GameController>();
        panelInfoCardHand = gameObject.transform.parent.gameObject;
        card = panelInfoCardHand.transform.GetChild(3).gameObject;
        GameObject imageChild =panelInfoCardHand.transform.GetChild(2).gameObject;
        imagePanelCard = imageChild.GetComponent<Image>();
        Image imageCard = card.GetComponent<Image>();
        spriteCard = imageCard.sprite;
        imagePanelCard.sprite = spriteCard;
        cardController = card.GetComponent<CardController>();
        cardEffect = card.GetComponent<MonoBehaviour>();
        if(!gameController.IsSummondCardInTurn)
        {
            gameObject.SetActive(false);    
        }


        effectActivatePanel = GameObject.Find("EffectActivatePanel");
        increasePanel = GameObject.Find("IncreasePanel");
        imageIncreasePanel = increasePanel.GetComponent<Image>();
        board = GameObject.Find("Board");
        lurePanel = GameObject.Find("LurePanel");
        imageLurePanel = lurePanel.GetComponent<Image>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            OnClick();
        }
        if(Input.GetKey(KeyCode.Escape)) 
        {
            OnClick(); 
        }

    }
    public void OnClick()
    {

        if (cardController.infoCard is CardDataUnit unit )
        {
            if (unit.DropZone[0] )
            {
                card.transform.SetParent(SubBoardCard().transform.GetChild(1), false);
            }
            else if (unit.DropZone[1])
            {
                card.transform.SetParent(SubBoardCard().transform.GetChild(2), false);
            }
            else if (unit.DropZone[2])
            {
                card.transform.SetParent(SubBoardCard().transform.GetChild(3), false);
            }
            card.SetActive(true);
        }
        else if(cardController.infoCard is CardDataIncrease)
        {
            imageIncreasePanel.enabled = true;
            card.SetActive(false);
            card.transform.SetParent(increasePanel.transform, false);
            increasePanel.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(cardController.infoCard is CardDataClimate)
        {
            CardDataClimate dataClimate = (CardDataClimate)cardController.infoCard;
            GameObject climateZone = GameObject.Find("ClimateZone");
            if(climateZone.transform.childCount < 4) 
            {
                card.transform.SetParent(climateZone.transform, false);
                card.SetActive(true);
            }
        }
        else if(cardController.infoCard is CardDataLure)
        {
            card.transform.SetParent(lurePanel.transform, false);
            card.SetActive(false);
            imageLurePanel.enabled = true;
            for(int i = 0; i < lurePanel.transform.childCount; i++)
            {
                lurePanel.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else if (cardController.infoCard is CardDataClearance)
        {
            CardDataClearance dataClearance = (CardDataClearance)cardController.infoCard;
            GameObject climateZone = GameObject.Find("ClimateZone");
            for(int i = 0;i< climateZone.transform.childCount;i++)
            {
                GameObject climateCard = climateZone.transform.GetChild(i).gameObject;
                climateCard.SetActive(false);
                Destroy(climateCard);
            }
            Destroy(card);
        }
        gameController.IsSummondCardInTurn = false;

        //desactivar panel de InfoHand
        for (int i = 0; i < panelInfoCardHand.transform.childCount; i++)
        {
            panelInfoCardHand.transform.GetChild(i).gameObject.SetActive(false);
        }
        imagePanelCard = panelInfoCardHand.GetComponent<Image>();
        imagePanelCard.enabled = false;
        cardEffect.enabled = true;
    }

    private GameObject SubBoardCard()
    {
        GameObject subBoard = null;

        if(table.transform.rotation.z == 0)
        {
            subBoard = GameObject.Find("SubBoardPlayer1");
        }
        else if(table.transform.rotation.z == 1)
        {
            subBoard = GameObject.Find("SubBoardPlayer2");

        }
        return subBoard;
    }

  }
