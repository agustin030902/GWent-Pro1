using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMinusZone : MonoBehaviour
{
    //private GameController gameController;
    //private GameObject board;
    private GameObject subBoard1;
    private GameObject subBoard2;
    private GameObject cemetery1;
    private GameObject cemetery2;
  

    //private GameObject MinusCardResult;

    //private int minusCard1 = 0;
    //private int minusCard2 = 0;

    private void OnEnable()
    {
        //board = GameObject.Find("Board");
        GameObject table = GameObject.Find("Table");
        subBoard1 = GameObject.Find("SubBoardPlayer1");
        subBoard2 = GameObject.Find("SubBoardPlayer2");
        cemetery1 = subBoard1.transform.GetChild(7).gameObject;
        cemetery2 = subBoard2.transform.GetChild(7).gameObject;

        print(CardMinus(subBoard1).transform.childCount);
        print(CardMinus(subBoard2).transform.childCount);

        if (CardMinus(subBoard2).transform.childCount < CardMinus(subBoard1).transform.childCount)
        {
           // MinusCardResult = CardMinus(subBoard1);
            SendCardCementery(cemetery1, CardMinus(subBoard1));
        }
        else if(CardMinus(subBoard2).transform.childCount > CardMinus(subBoard1).transform.childCount)
        {
            //MinusCardResult = CardMinus(subBoard2);
            SendCardCementery(cemetery2, CardMinus(subBoard2));

        }
        else
        {
            //print("Son iguales");
            if(table.transform.rotation.z == 1)
            {
                //MinusCardResult = CardMinus(subBoard1);
                SendCardCementery(cemetery1, CardMinus(subBoard1));

            }
            else
            {
                //MinusCardResult = CardMinus(subBoard2);
                SendCardCementery(cemetery2, CardMinus(subBoard2));

            }
        }


    }

    private GameObject CardMinus(GameObject subBoard)
    {
        int minusCardTemp = 0;
        GameObject cardMinus = new GameObject("vacio");
        for (int i = 1;i<=3 ;i++)
        {
            if(minusCardTemp < subBoard.transform.GetChild(i).childCount && subBoard.transform.GetChild(i).childCount != 0)
            {
                cardMinus = subBoard.transform.GetChild(i).gameObject;  
                minusCardTemp = subBoard.transform.GetChild(i).childCount;
            }
        }
        if(cardMinus.transform.name == "vacio")
        {
            Destroy(cardMinus);
            return null;
        }
        return cardMinus;

    }

    private void SendCardCementery(GameObject cemetery,GameObject zone)
    {
        //zone.gameObject.SetActive(false);
        for(int i = 0;i<zone.transform.childCount ;)
        {
            zone.transform.GetChild(0).SetParent(cemetery.transform,true);
        }

        print("pal cemetery");
    }

}
