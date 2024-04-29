using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackButtonField : MonoBehaviour
{
    private GameObject card;
    private GameObject panelInfoCardField;
    private Image imagePanel;
    private TMP_Text textPower;
    private CardController cardController;
    private void OnEnable()
    {
        panelInfoCardField = GameObject.Find("InfoCardField");
        imagePanel = panelInfoCardField.GetComponent<Image>();
        card = panelInfoCardField.transform.GetChild(3).gameObject;
        textPower = panelInfoCardField.transform.GetChild(2).GetComponent<TMP_Text>();
        cardController = card.GetComponent<CardController>();
        if(cardController.infoCard is CardDataUnit)
        {
            CardDataUnit unit = (CardDataUnit)cardController.infoCard;

            textPower.text = "Poder: "+unit.Power;
        }
        else if(cardController.infoCard is not CardDataUnit)
        {
            textPower.text = string.Empty;
        }

    }
    public void Back()
    {
        imagePanel.enabled = false;
        DesactivateAllChild();
        Destroy(card);
    }

    private void DesactivateAllChild()
    {
        for(int i=0;i<panelInfoCardField.transform.childCount ;i++)
        {
            panelInfoCardField.transform.GetChild(i).gameObject.SetActive(false);
        }

    }
}
