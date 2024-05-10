using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvokeIncreaseCard : MonoBehaviour
{
    public int zoneAtk;
    private GameObject card;
    private GameObject table;
    private GameObject subBoard;
    private GameObject targetZone;
    private GameObject increasePanel;
    private void OnEnable()
    {
        increasePanel = GameObject.Find("IncreasePanel");
        card = transform.parent.GetChild(4).gameObject;
        table = GameObject.Find("Table");
        if(table.transform.rotation.z == 0)
        {
            subBoard = GameObject.Find("SubBoardPlayer1");
        }
        else
        {
            subBoard = GameObject.Find("SubBoardPlayer2");
        }

        targetZone = subBoard.transform.GetChild(zoneAtk).gameObject;
    }

    public void SummondIncrease()
    {
        card.transform.SetParent(targetZone.transform,false);
        card.SetActive(true);
        //effectCard.enabled = true;  
        Back();
    }
    private void Back()
    {
        Image imagePanel = increasePanel.GetComponent<Image>();
        imagePanel.enabled = false;
        for (int i = 0; i < increasePanel.transform.childCount; i++)
        {
            increasePanel.transform.GetChild(i).gameObject.SetActive(false);
        }
        
    }
}
