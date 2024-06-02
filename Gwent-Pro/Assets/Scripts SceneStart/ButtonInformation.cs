using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInformation : MonoBehaviour
{
    GameObject principalMenu;
    GameObject panel;
    private void Start()
    {
        principalMenu = GameObject.Find("PrincipalMenu");
        panel = principalMenu.transform.GetChild(1).gameObject;

    }   
    public void OnMouseDown()
    {
        panel.SetActive(true);
        principalMenu.transform.GetChild(0).gameObject.SetActive(false);
    }

}
