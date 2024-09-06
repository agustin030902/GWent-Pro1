using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    private GameObject card;
    private GameObject cardDestiny;
    private GameObject panelInfoCardHand;
    private Image imagePanelHand;
    private GameController gameController;
    private GameObject table;
    
    private void OnEnable()
    {
        panelInfoCardHand = GameObject.Find("InfoCardHand");
        card = panelInfoCardHand.transform.GetChild(3).gameObject;
        GameObject board = GameObject.Find("Board");
        gameController = board.GetComponent<GameController>();
        imagePanelHand = panelInfoCardHand.GetComponent<Image>();
        Image cardImage = card.GetComponent<Image>();
        table = GameObject.Find("Table");
    }

    public void BackCard()
    {
        if (table.transform.rotation.z == 0) 
        {
            cardDestiny = GameObject.Find("Player1 Hand");
        }
        else if (table.transform.rotation.z == 1)
        {
            cardDestiny = GameObject.Find("Player2 Hand");
        }
        card.transform.SetParent(cardDestiny.transform, false);
        card.SetActive(true);
        DesactivateAllChild(panelInfoCardHand);
        panelInfoCardHand.transform.GetChild(1).gameObject.SetActive(false); 
        imagePanelHand.enabled = false;
    }
    private void DesactivateAllChild(GameObject panel)
    {
        for (int i = 0;i < panel.transform.childCount;i++) 
        {
            panel.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

}
