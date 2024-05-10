using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerOponent : MonoBehaviour
{
    private GameObject powerPanel;
    private Image imagePowerPanel;
    private void Awake()
    {
        powerPanel = GameObject.Find("PowerPanel");
        imagePowerPanel = powerPanel.GetComponent<Image>();
    }
    public void OnClick()
    {
        imagePowerPanel.enabled = true;
        for(int i = 0; i < powerPanel.transform.childCount ;i++)
        {
            powerPanel.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

}
