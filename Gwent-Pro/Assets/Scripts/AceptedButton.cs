    using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AceptedButton : MonoBehaviour
{
    public TMP_Text tMP;
    private GameObject table;
    private GameController gameController;
    private Image image;
    private GameObject board;
    private GameObject panelPassTurn;

    private void OnEnable()
    {
        table = GameObject.Find("Table");
        board = GameObject.Find("Board");
        gameController = board.GetComponent<GameController>();
        panelPassTurn = transform.parent.gameObject;
        image = panelPassTurn.GetComponent<Image>();
    }
    public void OnClick()
    {
        table = GameObject.Find("Table");
        board = GameObject.Find("Board");
        gameController = board.GetComponent<GameController>();
        panelPassTurn = gameObject.transform.parent.gameObject;
        image =panelPassTurn.GetComponent<Image>();

        if(table.transform.rotation.z == 1 && !gameController.IsFinishRound1)
        {
            table.transform.rotation = Quaternion.Euler(0, 0, 0);
            gameController.TurnNumberPlayer2++;
            image.enabled = false;

        }
        else if(table.transform.rotation.z == 0 && !gameController.IsFinishRound2) 
        {
            table.transform.rotation = Quaternion.Euler(0, 0, 180);
            gameController.TurnNumberPlayer1++;
            image.enabled = false;

        }
        DesactivateAll(panelPassTurn);
        gameController.IsSummondCardInTurn = true;
        image.enabled = !true;
    }
    private void DesactivateAll(GameObject PanelPassTurn)
    {
        for(int i = 0; i < PanelPassTurn.transform.childCount; i++) 
        {
            PanelPassTurn.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
