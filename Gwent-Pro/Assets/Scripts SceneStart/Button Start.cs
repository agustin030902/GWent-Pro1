using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonStart : MonoBehaviour
{
    public UIBehaviour uI;
    
    public void OnMouseDown()
    {
        print("hice click en el gameObject");
    }
    public void OnMouseEnter()
    {
        print("Entre al gameObject");
    }
    public void OnMouseExit()
    {
        print("Sali del gameObject");
    }
}
