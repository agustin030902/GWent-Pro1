using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardController : MonoBehaviour
{
    public  Card infoCard;
    private GameObject panelInfoCardHand;
    private GameObject panelInfoCardField;
    private Image imagePanelHand;
    private Image imagePanelField;
    private Image imageCardInPanel;
    private Image imageCard;
    private Sprite spriteCard;
    private GameObject buttonInvoke;
    private GameObject imageChildPanel;
    private GameObject handPlayer;
    private GameObject changeZone;
    private GameObject increaseZone;
    private GameObject increaseCard;
    private CardDataIncrease cardDataIncrease;
    private bool isIncreasePower = false;
    private int climateModificatePower = 0;
    private bool isSaveLeader = false;
    public bool IsIncreasePower { get => isIncreasePower; set => isIncreasePower = value; }
    public int ClimateModificatePower { get => climateModificatePower; set => climateModificatePower = value; }
    public bool IsSaveLeader { get => isSaveLeader; set => isSaveLeader = value; }

    private void Awake()
    {
        GameObject panelTwoCards = GameObject.Find("TwoCardsReturnPanel");
        if (panelTwoCards != null)
        {
            handPlayer = panelTwoCards.transform.GetChild(0).gameObject;
            changeZone = panelTwoCards.transform.GetChild(1).gameObject;
        }
        panelInfoCardHand = GameObject.Find("InfoCardHand");
        panelInfoCardField = GameObject.Find("InfoCardField");
        buttonInvoke = panelInfoCardHand.transform.GetChild(1).gameObject;
        imagePanelHand = panelInfoCardHand.GetComponent<Image>();
        imagePanelField = panelInfoCardField.GetComponent<Image>();
        imageCardInPanel = panelInfoCardField.transform.GetChild(1).gameObject.GetComponent<Image>();
        imageCard = GetComponent<Image>();
    }
    private void OnMouseEnter()
    {
        print("hice Click");
    }
    private void Update()
    {

        


        if (infoCard is CardDataUnit unit)
        {
            if(transform.parent.parent.name == "TwoCardsReturnPanel")
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z);
            }

            if (transform.parent.name == "MeleeZone")
            {
                CardDataUnit cardDataUnit = unit;
                increaseZone = transform.parent.parent.GetChild(4).gameObject;
                if (increaseZone.transform.childCount == 1)
                {
                    increaseCard = increaseZone.transform.GetChild(0).gameObject;
                    CardController cardController = increaseCard.GetComponent<CardController>();
                    cardDataIncrease = (CardDataIncrease)cardController.infoCard;
                    if (!IsIncreasePower && cardDataUnit.Type != "hero")
                    {
                        isIncreasePower = true;
                        cardDataUnit.Power += cardDataIncrease.Increase;
                    }
                }
            }
            else if (transform.parent.name == "RangeZone")
            {
                CardDataUnit cardDataUnit = unit;
                increaseZone = transform.parent.parent.GetChild(5).gameObject;
                if (increaseZone.transform.childCount == 1)
                {
                    increaseCard = increaseZone.transform.GetChild(0).gameObject;
                    CardController cardController = increaseCard.GetComponent<CardController>();
                    cardDataIncrease = (CardDataIncrease)cardController.infoCard;
                    if (!IsIncreasePower && cardDataUnit.Type != "hero")
                    {
                        isIncreasePower = true;
                        cardDataUnit.Power += cardDataIncrease.Increase;
                    }
                }
            }
            else if (transform.parent.name == "SiegeZone")
            {
                CardDataUnit cardDataUnit = unit;
                increaseZone = transform.parent.parent.GetChild(6).gameObject;
                if (increaseZone.transform.childCount == 1)
                {
                    increaseCard = increaseZone.transform.GetChild(0).gameObject;
                    CardController cardController = increaseCard.GetComponent<CardController>();
                    cardDataIncrease = (CardDataIncrease)cardController.infoCard;
                    if (!IsIncreasePower && cardDataUnit.Type != "hero")
                    {
                        isIncreasePower = true;
                        cardDataUnit.Power += cardDataIncrease.Increase;
                    }
                }
            }
        }

        // Efecto Permanente de las cartas Clima
        if(infoCard is CardDataClimate)
        {
            CardDataClimate climate = (CardDataClimate)infoCard;
            GameObject climateZone = GameObject.Find("ClimateZone");
            //print((climateZone.transform.childCount));
            if (climate.IsActivateClimate)
            {
                for (int i = 0; i <= 2 && climate.AfectationZone[i]; i++)
                {
                    climate.AfectionPowerCard(climateZone.transform.childCount,i+1);
                }
            }
        }


    }
    public void SummonCard()
    {
        if (gameObject.transform.parent.name == "Player2 Hand" || gameObject.transform.parent.name == "Player1 Hand")
        {
            imagePanelHand.enabled = true;
            gameObject.transform.SetParent(panelInfoCardHand.transform, false);
            gameObject.SetActive(false);
            for (int i = 0; i < panelInfoCardHand.transform.childCount-1; i++) 
            {
                panelInfoCardHand.transform.GetChild(i).gameObject.SetActive(true);
            }
            if (infoCard is CardDataUnit)
            {
                CardDataUnit unit = (CardDataUnit)infoCard;
                unit.Power = unit.OriginPower;
            }
            


        }
    }
    public void InfoCard()
    {
        if (transform.parent.gameObject.transform.parent.gameObject.transform.parent.name == "Board" && transform.parent.gameObject.name != "Cemetery" || transform.parent.name =="ClimateZone" )
        {
            MonoBehaviour effect = GetComponent<MonoBehaviour>();
            if (effect is not Image)
            {
                effect.enabled = false;
            }
            GameObject cloneCard = Instantiate(gameObject, panelInfoCardField.transform);
            cloneCard.SetActive(false);
            

            for (int i = 0; i < panelInfoCardField.transform.childCount; i++)
            {
                panelInfoCardField.transform.GetChild(i).gameObject.SetActive(true);
            }
            imagePanelField.enabled = true;
            imageCardInPanel.sprite = imageCard.sprite;
        }


    }
    public void TwoCardReturn()
    {
        if(transform.parent.name == "HandPlayer" && changeZone.transform.childCount < 2)
        {
            transform.SetParent(changeZone.transform,false);
        }
        else if (transform.parent.name == "ChangeZone" )
        {
            transform.SetParent(handPlayer.transform,true);
        }
        else if (transform.parent.name == "SustitutionZone" && GameObject.Find("SelectionZone").transform.childCount == 0)
        {
            transform.SetParent(GameObject.Find("SelectionZone").transform,false);
        }
        else if(transform.parent.name == "SelectionZone")
        {
            transform.SetParent(GameObject.Find("SustitutionZone").transform,false);       
        }
    }

}
