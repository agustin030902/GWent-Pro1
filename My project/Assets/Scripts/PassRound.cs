using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class PassRound : MonoBehaviour
{
    private GameObject finishRoundPanel;
    private UnityEngine.UI.Image imageFinishRoundPanel;
    private GameObject board;
    private GameController gameController;
    private GameObject table;
    public TMP_Text text;
    private void OnEnable()
    {
        board = GameObject.Find("Board");
        table = GameObject.Find("Table");
        finishRoundPanel = GameObject.Find("FinalizateRoundPanel");
        imageFinishRoundPanel = finishRoundPanel.GetComponent<UnityEngine.UI.Image>();
        gameController= board.GetComponent<GameController>();
    }

    public void OnClick()
    {

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
