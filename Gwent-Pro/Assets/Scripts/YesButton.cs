using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class YesButton : MonoBehaviour
{
    GameObject leaderCard;
    CardController cardController;
    CardDataLeader leaderCardData;
    GameObject subBoard;
    GameObject table;
    GameObject panel;
    private GameObject finishRoundPanel;
    private UnityEngine.UI.Image imageFinishRoundPanel;
    private GameObject board;
    private GameController gameController;
    public TMP_Text text;
    private void Start()
    {
        table = GameObject.Find("Table");
        panel = transform.parent.gameObject;
        board = GameObject.Find("Board");
        finishRoundPanel = GameObject.Find("FinalizateRoundPanel");
        imageFinishRoundPanel = finishRoundPanel.GetComponent<UnityEngine.UI.Image>();
        gameController = board.GetComponent<GameController>();
        if (table.transform.rotation.z ==1)
        {
            leaderCard = GameObject.Find("SubBoardPlayer2").transform.GetChild(8).GetChild(0).gameObject;
            subBoard = GameObject.Find("SubBoardPlayer2");
        }
        else if(table.transform.rotation.z == 0)
        {
            leaderCard = GameObject.Find("SubBoardPlayer1").transform.GetChild(8).GetChild(0).gameObject;
            subBoard = GameObject.Find("SubBoardPlayer1");
        }
        cardController = leaderCard.GetComponent<CardController>();
        leaderCardData = (CardDataLeader)cardController.infoCard;
    }
    public void OnMouseDown()
    {
        if (transform.name == "YesButton")
        {
            leaderCardData.Effect(subBoard);
        }

         ActivateFinishPanel();
         Image image = panel.GetComponent<Image>();
         for (int i = 0; i < panel.transform.childCount; i++)
         {
            panel.transform.GetChild(i).gameObject.SetActive(false);
         }
         image.enabled = false;
    }

    private void ActivateFinishPanel()
    {
        text = finishRoundPanel.transform.GetChild(1).gameObject.GetComponent<TMP_Text>();
        for (int i = 0; i < finishRoundPanel.transform.childCount; i++)
        {
            finishRoundPanel.transform.GetChild(i).gameObject.SetActive(true);
        }
        imageFinishRoundPanel.enabled = true;
        if (table.transform.rotation.z == 1)
        {
            string info = "Player2 ha terminado su ronda";
            text.text = info;
            gameController.RoundNumberPlayer2++;
        }
        else
        {
            string info = "Player1 ha terminado su ronda";
            text.text = info;
            gameController.RoundNumberPlayer1++;
        }


    }
}
