using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PassTurn : MonoBehaviour
{
    private GameObject table;
    private GameController gameController;
    private GameObject passTurnPanel;
    private Image image;
    private void Awake()
    {
        GameObject board = GameObject.Find("Board");
        table = GameObject.Find("Table");
        passTurnPanel = GameObject.Find("PassTurn");
        gameController = board.GetComponent<GameController>();
        image = passTurnPanel.GetComponent<Image>();
    }
    public void OnClick()
    {
        GameObject textMeshPro = passTurnPanel.transform.GetChild(1).gameObject;
        TMP_Text text = textMeshPro.GetComponent<TMP_Text>();
        image.enabled = true;
        for (int i = 0;passTurnPanel.transform.childCount > i ;i++) 
        {
            passTurnPanel.transform.GetChild(i).gameObject.SetActive(true); 
        }
        if(table.transform.rotation.z == 1 )
        {
            string info = "Player2 ha pasado turno";
            text.text = info;
        }
        else
        {
            string info = "Player1 ha pasado turno";
            text.text = info;
        }

    }
}
