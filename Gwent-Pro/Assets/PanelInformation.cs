using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInformation : MonoBehaviour
{
    float posYUp = 1040;
    float posYDown = 3800;
    GameObject panel;
    private void Start()
    {
        panel = gameObject;
    }
    private void Update()
    {
        if (panel.transform.position.y < posYUp)
        {
            panel.transform.position = new Vector2(panel.transform.position.x,posYUp);
        }
        else if(panel.transform.position.y > posYDown)
        {
            panel.transform.position = new Vector2(panel.transform.position.x, posYDown);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            panel.transform.position = new Vector2(panel.transform.position.x,1.01f*panel.transform.position.y);
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            panel.transform.position = new Vector2(panel.transform.position.x,0.98f* panel.transform.position.y);
        }

    }
}
