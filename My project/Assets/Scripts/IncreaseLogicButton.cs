using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseLogicButton : MonoBehaviour
{
    private GameObject card;
    private GameObject table;
    private GameObject subBoard;
    private GameObject increasePanel;
    private GameObject handPlayer;

    private void OnEnable()
    {
        GameObject panel = transform.parent.gameObject;
        card = panel.transform.GetChild(4).gameObject;
        table = GameObject.Find("Table");
        increasePanel = transform.parent.gameObject;

        if(table.transform.rotation.z == 0)
        {
            subBoard = GameObject.Find("SubBoardPlayer1");
            handPlayer = GameObject.Find("Player1 Hand");
        }
        else if(table.transform.rotation.z == 1)
        {
            subBoard = GameObject.Find("SubBoardPlayer2");
            handPlayer = GameObject.Find("Player2 Hand");

        }

        for (int i =4;i <= 6 ;i++)
        {
            if(subBoard.transform.GetChild(i).childCount == 0)
            {
                increasePanel.transform.GetChild(i-3).gameObject.SetActive(true);
            }
        }
    }
    public void Back()
    {
        Image imagePanel = increasePanel.GetComponent<Image>();
        imagePanel.enabled = false;
        for(int i =0;i<increasePanel.transform.childCount ;i++)
        {
            increasePanel.transform.GetChild(i).gameObject.SetActive(false);
        }
        card.transform.SetParent(handPlayer.transform,false);
        card.SetActive(true);
    }

}
