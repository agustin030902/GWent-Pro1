using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackButtonPowerPanel : MonoBehaviour
{
    private GameObject table;
    private GameController controller;
    private GameObject powerPanel;
    private GameObject powerText;
    private GameObject card;
    private TMP_Text textPower;
    private GameObject SubBoard1;
    private GameObject SubBoard2;
    private CardController cardController;
    private Image imagePanel;
    private void OnEnable()
    {
        GameObject board = GameObject.Find("Board");
        SubBoard1 = GameObject.Find("SubBoardPlayer1");
        SubBoard2 = GameObject.Find("SubBoardPlayer2");
        controller = board.GetComponent<GameController>();
        powerPanel = GameObject.Find("PowerPanel");
        powerText = powerPanel.transform.GetChild(0).gameObject;
        textPower = powerText.GetComponent<TMP_Text>();
        imagePanel = powerPanel.GetComponent<Image>();
        table = GameObject.Find("Table");

        ShowPower();
    }
    private void ShowPower()
    {
        if(table.transform.rotation.z == 0)
        {
            int totalPower = 0;
            for(int i = 0;i<3 ;i++)
            {
                totalPower += PowerCounter(SubBoard2.transform.GetChild(i+1).gameObject);
            }
            textPower.text = "Poder total: "+totalPower;
        }
        else if (table.transform.rotation.z == 1 )
        {
            int totalPower = 0;
            for (int i = 0; i < 3; i++)
            {
                totalPower += PowerCounter(SubBoard1.transform.GetChild(i + 1).gameObject);
            }
            textPower.text = "Poder total: " + totalPower;
        }

    }
    public void OnClick()
    {
        imagePanel.enabled = false;

        for(int i = 0;i<powerPanel.transform.childCount ; i++)
        {
            powerPanel.transform.GetChild(i).gameObject.SetActive(false);
        }

    }

    private int PowerCounter(GameObject playerZone)
    {
        int sum= 0;
        for (int i = 0; i<playerZone.transform.childCount ;i++) 
        {
            cardController = playerZone.transform.GetChild(i).GetComponent<CardController>();
            CardDataUnit unit = (CardDataUnit)cardController.infoCard;
            sum += unit.Power;
        }
        return sum;
    }

}
