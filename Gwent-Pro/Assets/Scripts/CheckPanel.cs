using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckPanel : MonoBehaviour
{
    private int indexVictoryPlayer1;
    private int indexVictoryPlayer2;
    private GameObject board;
    private GameObject panelFather;
    private GameObject mainCanvas;
    //private TMP_Text textPanel;
    private GameController gameController;
    private GameObject victoryPanel;
    private TMP_Text textVictoryPanel;
    private Image imagePanelFather;
    private Image imageVictoryPanel;
    private void OnEnable()
    {
        board = GameObject.Find("Board");
        mainCanvas = GameObject.Find("MainCanvas");
        panelFather = transform.parent.gameObject;
        GameObject gameObjectTextChild = panelFather.transform.GetChild(0).gameObject;
        //textPanel = gameObjectTextChild.GetComponent<TMP_Text>();
        gameController = board.GetComponent<GameController>();
        imagePanelFather = panelFather.GetComponent<Image>();
        victoryPanel = GameObject.Find("VictoryPanel");
        GameObject textGameObject = victoryPanel.transform.GetChild(0).gameObject;
        textVictoryPanel = textGameObject.GetComponent<TMP_Text>();
        imageVictoryPanel = victoryPanel.GetComponent<Image>();
        indexVictoryPlayer1 = 0;
        indexVictoryPlayer2 = 0;

        //Lo q quieres q diga el panel
        for (int i = 0; i < 3; i++)
        {
            if (gameController.PlayerVictory[i] == 1)
            {
                indexVictoryPlayer1++;
            }
            else if (gameController.PlayerVictory[i] == 2)
            {
                indexVictoryPlayer2++;
            }
        }
        CheckWin();
        

    }

    public void Acepted()
    {
        imagePanelFather.enabled = false;
        for (int i = 0;i < panelFather.transform.childCount;i++) 
        {
            panelFather.transform.GetChild(i).gameObject.SetActive(false);
        }
       
    }

    private void CheckWin()
    {
        if (indexVictoryPlayer1 == 2 || indexVictoryPlayer2 == 2)
        {
            DesactivateCheckPanel();
            ActivateVictoryPanel();

            if (indexVictoryPlayer1 == 2)
            {
                textVictoryPanel.text = "Player1 ha ganado la partida";
            }
            else if(indexVictoryPlayer2 == 2)
            {
                textVictoryPanel.text = "Player2 ha ganado la partida";
            }
            return;
        }
        else if (gameController.RoundNumberPlayer1 == 4 && gameController.RoundNumberPlayer2 == 4)
        {
            DesactivateCheckPanel();
            ActivateVictoryPanel();
            if (indexVictoryPlayer1 > indexVictoryPlayer2)
            {
                textVictoryPanel.text = "Player1 ha ganado la partida";
            }
            else if (indexVictoryPlayer1 < indexVictoryPlayer2)
            {
                textVictoryPanel.text = "Player2 ha ganado la partida";
            }
            else
            {
                textVictoryPanel.text = "La partida quedo empatada";
            }
        }


    }
    private void ActivateVictoryPanel()
    {
        imageVictoryPanel.enabled = true;

        for (int i = 0; i < victoryPanel.transform.childCount; i++)
        {
            victoryPanel.transform.GetChild(i).gameObject.SetActive(true);
        }

        for(int i = 0;i<mainCanvas.transform.childCount;i++)
        {
            if (mainCanvas.transform.GetChild(i).name != "VictoryPanel")
            {
                //mainCanvas.transform.GetChild(i).gameObject.SetActive(false);
                Destroy(mainCanvas.transform.GetChild(i).gameObject);

                //Image image = mainCanvas.transform.GetChild(i).GetComponent<Image>();
                //image.enabled = false;
            }
        }
    }

    private void DesactivateCheckPanel()
    {
        panelFather.SetActive(false);
    }
}
