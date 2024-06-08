using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderPanelController : MonoBehaviour
{
    GameObject fatherButton;
    GameObject cardLeader;
    GameObject leaderZone;
    GameObject table;
    GameObject subBoard;
    Image imageFatherPanel;

    private void OnEnable()
    {
    fatherButton = transform.parent.gameObject;

        imageFatherPanel = fatherButton.GetComponent<Image>();

        table = GameObject.Find("Table");

        subBoard = (table.transform.rotation.z == 1) ? GameObject.Find("SubBoardPlayer2") : GameObject.Find("SubBoardPlayer1");

        leaderZone = subBoard.transform.GetChild(8).gameObject;

        cardLeader = leaderZone.transform.GetChild(0).gameObject;
    }
    public void OnMouseDown()
    {
        print(fatherButton.name);
        CardController controller = cardLeader.GetComponent<CardController>();  
        CardDataLeader cardDataLeader = (CardDataLeader)controller.infoCard;
        List<GameObject> list = new List<GameObject>();
        for(int i = 1; i < 4; i++)
        {
            for(int j = 0; j < subBoard.transform.GetChild(i).childCount ;j++)
            {
                list.Add(subBoard.transform.GetChild(i).GetChild(j).gameObject);
            }
        }
        int random = Random.Range(0,list.Count-1);
        //print(random.ToString());
        //cardDataLeader.IsActivateEffects = true;
        if (gameObject.name == "YesButton")
        {
            CardController cardController = list[random].GetComponent<CardController>();
            cardController.IsSaveLeader = true;
            if(table.transform.rotation.z == 1)
            {
                table.transform.rotation = Quaternion.Euler(0,0,0);
            }
            else
            {
                table.transform.rotation = Quaternion.Euler(0, 0,180);
            }           
        }
        else if(gameObject.name == "NoButton")
        {
            if (table.transform.rotation.z == 1)
            {
                table.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                table.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
        imageFatherPanel.enabled = false;
        for (int i = 0; i < fatherButton.transform.childCount; i++)
        {
            fatherButton.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
