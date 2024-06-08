using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton_StartScene : MonoBehaviour
{
    GameObject principalMenu;
    GameObject panelPrincipal;
    GameObject panel;
    private void Start()
    {
        principalMenu = GameObject.Find("PrincipalMenu");
        panelPrincipal = principalMenu.transform.GetChild(0).gameObject;
        panel = principalMenu.transform.GetChild(1).gameObject;

    }
    public void OnMouseDown()
    {
        panel.SetActive(false);
        panelPrincipal.SetActive(true);
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Backspace))
        {
            OnMouseDown();
        }
    }
}
