using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="Leader Info",menuName ="Card Data Leader")]
public class CardDataLeader : Card
{
    [SerializeField] internal string Faction { get; set; }

    [SerializeField] private bool isActivateEffects = false;

    public CardDataLeader(string faction)
    {
        Faction = faction;
    }

    public bool IsActivateEffects { get => isActivateEffects;  set => isActivateEffects = value; }
    public void Effect(GameObject subBoard)
    {
        GameObject table = GameObject.Find("Table");
        List<GameObject> list = new List<GameObject>();
        subBoard = (table.transform.rotation.z == 1) ? GameObject.Find("SubBoardPlayer2"):GameObject.Find("SubBoardPlayer1") ;
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
        //IsActivateEffects = true;
    }

}
