using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalizateRound : MonoBehaviour
{
    private GameController gameController;
    private GameObject board;
    private GameObject panelFinishRound;
    private Image imagePanelFinishRound;
    private GameObject table;
    private GameObject leaderEffect;
    private GameObject leaderZone;
    private GameObject leaderCard;
    private CardController cardController;
    private CardDataLeader leaderCardData;
    private void Start()
    {
        board = GameObject.Find("Board");
        table = GameObject.Find("Table");
        gameController = board.GetComponent<GameController>();
        panelFinishRound = transform.parent.gameObject;
        imagePanelFinishRound = panelFinishRound.GetComponent<Image>();
        leaderEffect = GameObject.Find("LeaderPanel");
        leaderZone = GameObject.Find("LeaderZone");
        leaderCard = leaderZone.transform.GetChild(0).gameObject;
        cardController = leaderCard.GetComponent<CardController>();
        leaderCardData = (CardDataLeader)cardController.infoCard;
    }
    public void OnClick()
    {
        for(int i = 0; i < panelFinishRound.transform.childCount; i++)
        {
            panelFinishRound.transform.GetChild(i).gameObject.SetActive(false);
        }
        if(table.transform.rotation.z == 1)
        {
            gameController.IsFinishRound2 = true;
            if (leaderCardData.IsActivateEffects)
            {
                ActivateEffectSaveCard();
            }
            if (gameController.IsFinishRound1)
            {
                gameController.IsSummondCardInTurn = true;
            }
            //table.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (table.transform.rotation.z == 0)
        {
            gameController.IsFinishRound1 = true;
            if(leaderCardData.IsActivateEffects)
            {
            ActivateEffectSaveCard();
            }
            //table.transform.rotation = Quaternion.Euler(0, 0,180);

            if (gameController.IsFinishRound2)
            {
                gameController.IsSummondCardInTurn = true;
            }
        }
        imagePanelFinishRound.enabled = false;
        gameController.IsSummondCardInTurn = true;
    }
    private void ActivateEffectSaveCard()
    {
        Image imageEffectLeaderPanel = leaderEffect.GetComponent<Image>();
        imageEffectLeaderPanel.enabled = true;

        for(int i = 0; i < leaderEffect.transform.childCount; i++) 
        {
            leaderEffect.transform.GetChild(i).gameObject.SetActive(true);
        }

    }
}
