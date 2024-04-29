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
    private void OnEnable()
    {
        board = GameObject.Find("Board");
        table = GameObject.Find("Table");
        gameController = board.GetComponent<GameController>();
        panelFinishRound = transform.parent.gameObject;
        imagePanelFinishRound = panelFinishRound.GetComponent<Image>();
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
            if (gameController.IsFinishRound1)
            {
                //imagePanelFinishRound.enabled = false;
                gameController.IsSummondCardInTurn = true;
            }
            else
            {
                table.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else if (table.transform.rotation.z == 0)
        {
            gameController.IsFinishRound1 = true;
            if (gameController.IsFinishRound2)
            {
               // imagePanelFinishRound.enabled = false;
                gameController.IsSummondCardInTurn = true;
            }
            else
            {
                table.transform.rotation = Quaternion.Euler(0, 0, 180);
            }

        }
        imagePanelFinishRound.enabled = false;
        gameController.IsSummondCardInTurn = true;
    }
    
  

}
