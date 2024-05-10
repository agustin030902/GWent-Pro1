using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvokeCard : MonoBehaviour
{
    private GameObject card;
    private Image imageCard;
    private Sprite spriteCard;
    private CardController cardController;
    private GameObject panelInfoCardHand;
    private GameController gameController;
    private GameObject subBoard;
    private void Awake()
    {
        panelInfoCardHand = GameObject.Find("InfoCardHand");
        card = panelInfoCardHand.transform.GetChild(3).gameObject;
        Image image = card.GetComponent<Image>();
        spriteCard = image.sprite;
        imageCard = panelInfoCardHand.transform.GetChild(2).GetComponent<Image>();
        imageCard.sprite = spriteCard;
        cardController = card.GetComponent<CardController>();
        GameObject board = GameObject.Find("Board");
        gameController = board.GetComponent<GameController>();
    }
    public void OnClick()
    {
        print(card);
        print(SubBoardCard());
        if (cardController.infoCard is CardDataUnit)
        {
            CardDataUnit unit = (CardDataUnit)cardController.infoCard;
            if (unit.DropZone[0])
            {
                card.transform.SetParent(SubBoardCard().transform.GetChild(1), true);
            }
            else if (unit.DropZone[1])
            {
                card.transform.SetParent(SubBoardCard().transform.GetChild(2), false);
            }
            else if (unit.DropZone[2])
            {
                card.transform.SetParent(SubBoardCard().transform.GetChild(3), false);

            }
        }
        card.SetActive(true);
        for (int i = 0; i < panelInfoCardHand.transform.childCount ; i++)
        {
            panelInfoCardHand.transform.GetChild(i).gameObject.SetActive(false);
        }
        Image imagePanel = panelInfoCardHand.GetComponent<Image>();
        imagePanel.enabled = false;
    }
    private GameObject SubBoardCard()
    {
        

        if(gameController.TurnNumberPlayer1 == gameController.TurnNumberPlayer2)
        {
            subBoard = GameObject.Find("SubBoardPlayer1");
        }
        if(gameController.TurnNumberPlayer2 < gameController.TurnNumberPlayer1) 
        {
            subBoard = GameObject.Find("SubBoardPlayer2");

        }

        return subBoard;
    }
    

}
