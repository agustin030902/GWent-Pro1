using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    private GameObject panelFather;
    private Image imagePanel;
    private GameObject checkPanel;
    private TMP_Text panelText;
    private GameController gameController;
    private GameObject table;
    private void OnEnable()
    {
        panelFather = transform.parent.gameObject;
        imagePanel = panelFather.GetComponent<Image>();

        table = GameObject.Find("Table");
        GameObject board = GameObject.Find("Board");
        checkPanel = GameObject.Find("CheckPanel");
        GameObject gameObjectText = checkPanel.transform.GetChild(0).gameObject;
        gameController = board.GetComponent<GameController>();
        panelText = gameObjectText.GetComponent<TMP_Text>();
    }
    public void Back()
    {
        imagePanel.enabled = false;
        for (int i = 0;i < panelFather.transform.childCount;i++)
        {
            panelFather.transform.GetChild(i).gameObject.SetActive(false);  
        }
        if (table.transform.rotation.z == 0)
        {
            table.transform.rotation = Quaternion.Euler(180, 0, 0);
        }
        else if (table.transform.rotation.z == 1)
        {
            table.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnDisable()
    {
        Image imageCheckPanel = checkPanel.GetComponent<Image>();  
        imageCheckPanel.enabled = true;
        for (int i = 0;i<checkPanel.transform.childCount ;i++)
        {
            checkPanel.transform.GetChild(i).gameObject.SetActive(true);
        }
        if(gameController.PlayerVictory[gameController.RoundNumberPlayer1 - 2] == 2)
        {
            panelText.text = "player2 ha ganado la ronda " + (gameController.RoundNumberPlayer1 - 1);

        }
        else if (gameController.PlayerVictory[gameController.RoundNumberPlayer1-2] == 1)
        {
            panelText.text = "player1 ha ganado la ronda "+ (gameController.RoundNumberPlayer1 - 1);
        }
        else
        {
            panelText.text = "La ronda ha terminado en empate";
        }

    }
}
