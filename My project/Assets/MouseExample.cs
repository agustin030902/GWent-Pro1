using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseExample : MonoBehaviour
{
    void Update()
    {
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        mousePosition.z = 0;
        transform.position = mousePosition;

        print(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(mousePosition,transform.position,out hit))
        {
            print(hit.collider.gameObject.name);
        }
        else
        {
            print("Es null");
        }
    }
    
}
