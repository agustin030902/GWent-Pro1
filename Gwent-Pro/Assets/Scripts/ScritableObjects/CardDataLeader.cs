using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="Leader Info",menuName ="Card Data Leader")]
public class CardDataLeader :Card
{
    private bool isActivateEffects = false;
    public bool IsActivateEffects { get => isActivateEffects; set => isActivateEffects = value; }
    public void Effect(GameObject subBoard)
    {
        GameObject table = GameObject.Find("Table");
        List<GameObject> list = new List<GameObject>();
        subBoard = (table.transform.rotation.z == 1) ? GameObject.Find("SubBoardPlayer2"):GameObject.Find("SubBoardPlayer1") ;
        Debug.Log(subBoard.name);   
        for (int i = 1;i<=6;i++)
        {
            if (subBoard.transform.childCount > 0)
            {
                for (int j = 0; j < subBoard.transform.GetChild(i).childCount; j++)
                {
                    list.Add(subBoard.transform.GetChild(i).GetChild(j).gameObject);
                }
            }
        }


        int x = Random.Range(0,list.Count-1);

        CardController cardController = list[x].GetComponent<CardController>();
        cardController.IsSaveLeader = true;
        IsActivateEffects = true;
    }

}
