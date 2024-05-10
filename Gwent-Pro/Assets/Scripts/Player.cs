using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Player 
{
    private readonly GameObject subBoard;
    private readonly List<GameObject> deck;
    private readonly GameObject handPlayer;
    private GameObject handPlayerDesactivate;
    private int[] roundPts;
    private GameObject table;
    public Player(GameObject subBoard, List<GameObject> deck, GameObject handPlayer)
    {
        this.subBoard = subBoard;
        this.deck = deck;
        this.handPlayer = handPlayer;
        table = GameObject.Find("Table");
        roundPts = new int[3];
    }

    public GameObject SubBoard { get => subBoard;}
    public List<GameObject> Deck { get => deck;}
    public GameObject HandPlayer { get => handPlayer;}
    public int[] RoundPts { get => roundPts; set => roundPts = value; }

    public void Initialize()
    {
        GameObject deckZone = this.subBoard.transform.GetChild(0).gameObject;
        int totalCards = deck.Count;
        for (int i = 0; i < totalCards; i++) 
        {
            GameObject card = GameObject.Instantiate(deck[0],new Vector2(0,0),Quaternion.identity);
            card.transform.SetParent(deckZone.transform,false);
            deck.RemoveAt(0);
        }
    }
    public void Draw()
    {
        int totalChild = table.transform.childCount;
        if (subBoard.name == "SubBoardPlayer2")
        {
            handPlayerDesactivate = table.transform.GetChild(totalChild-2).gameObject; 
        }
        if (subBoard.name == "SubBoardPlayer1")
        {
            handPlayerDesactivate = table.transform.GetChild(totalChild-1).gameObject;
        }
        GameObject deckZone = this.subBoard.transform.GetChild(0).gameObject;
        int indexCard = Random.Range(0, deckZone.transform.childCount - 2);
        GameObject card = deckZone.transform.GetChild(indexCard).gameObject;
        card.transform.SetParent(handPlayerDesactivate.transform,false);
    }
}