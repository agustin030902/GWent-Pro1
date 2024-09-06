using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionGame : MonoBehaviour
{
    GameObject GameZone { get; set; }
    GameObject ButtonPlayer1 { get; set; }
    GameObject ButtonPlayer2 { get; set; }
    GameObject SelectionZone { get; set; }
    GameObject Board {  get; set; }
    void Start()
    {
        print(gameObject);
        GameZone = transform.GetChild(1).gameObject;

        print(GameZone);

        if (DataBaseScript.data is null || DataBaseScript.data.DataBase.List.Count == 0)
        {
            GameZone.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
            return;
        }

        ButtonPlayer1 = GameObject.Find("Player 1");
        ButtonPlayer2 = GameObject.Find("Player 2");
        SelectionZone = GameObject.Find("SelectionZone");
        Board = GameZone.transform.GetChild(0).GetChild(0).gameObject;

        SelectPlayer selectPlayer1 = ButtonPlayer1.GetComponent<SelectPlayer>();
        SelectPlayer selectPlayer2 = ButtonPlayer2.GetComponent<SelectPlayer>();
        GameController controller = Board.GetComponent<GameController>();
        selectPlayer1.deck = controller.Deck1;
        selectPlayer2.deck = controller.Deck2;
        foreach (var card in DataBaseScript.data.DataBase.List)
        {
            GameObject.Instantiate(card.transform, SelectionZone.transform);
        }

        StartCoroutine(UpdateCoroutine());
    }
    private IEnumerator UpdateCoroutine()
    {
       

        while (true)
        {
            print(GameZone);
            print(SelectionZone);
            if (SelectionZone.transform.childCount == 0 && GameObject.Find("InfoCard").transform.childCount == 0)
            {
                GameZone.SetActive(true);
                transform.GetChild(0).gameObject.SetActive(false);
                SelectionGame selection = GetComponent<SelectionGame>();
                selection.enabled = false;
                break;
            }

            yield return null;
        }

    }

    //private void Update()
    //{
    //    GameZone = transform.GetChild(1).gameObject;
    //    SelectionZone = GameObject.Find("SelectionZone");

    //    if(SelectionZone.transform.childCount == 0 && GameObject.Find("InfoCard").transform.childCount == 0)
    //    {
    //        GameZone.SetActive(true);
    //        transform.GetChild(0).gameObject.SetActive(false);
    //        SelectionGame selection = GetComponent<SelectionGame>();
    //        selection.enabled = false;
    //    }
    //}

}
