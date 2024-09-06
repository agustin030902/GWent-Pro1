using Gwent_Compiler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

namespace Gwent_Game
{
    public class Player
    {
        private readonly GameObject subBoard;
        internal List<GameObject> Deck { get; set; }
        internal GameObject HandPlayer { get; set; }
        private readonly GameObject table;
        private GameObject handPlayerDesactivate;
        internal Player OtherPlayer { get; set; }
        private int[] roundPts;
        internal int IdPlayer {  get; set; }
        public Player(GameObject subBoard, List<GameObject> deck, GameObject handPlayer)
        {
            this.subBoard = subBoard;
            Deck = deck;
            HandPlayer = handPlayer;
            table = GameObject.Find("Table");
            roundPts = new int[3];
        }
        public Player() { }
        public GameObject SubBoard { get => subBoard; }
        public int[] RoundPts { get => roundPts; set => roundPts = value; }

        public void Initialize()
        {
            GameObject deckZone = this.subBoard.transform.GetChild(0).gameObject;
            int totalCards = Deck.Count;

            Deck = Shuffle(Deck);

            for (int i = 0; i < totalCards; i++)
            {
                GameObject card = GameObject.Instantiate(Deck[0], new Vector2(0, 0), Quaternion.identity);
                
                if (card.TryGetComponent<Button>(out var button))
                {
                    for (int j = 0; j < button.onClick.GetPersistentEventCount(); j++)
                    {
                        button.onClick.SetPersistentListenerState(j, UnityEngine.Events.UnityEventCallState.RuntimeOnly);
                    }
                }

                if (card.GetComponent<CardController>() is not null)
                {
                    CardController cardController = card.GetComponent<CardController>();
                    cardController.infoCard.IdCard = (IdPlayer == 1) ? 1 : 2;
                    cardController.enabled = true;
                   // Debug.Log(cardController.infoCard.IdCard);
                }   
                card.transform.SetParent(deckZone.transform, false);

                Deck.RemoveAt(0);
            }
        }
        public List<GameObject> Shuffle(List<GameObject> deck)
        {
            List<GameObject> cards = new();
            int a = deck.Count;

            for(int i = 0;i < a;i++)
            {
                int index = UnityEngine.Random.Range(0, deck.Count-1);
                //Debug.Log("Mi catidad de cartas es "+deck.Count + " y mi index es:"+index+ " cards in deck"+cards.Count);

                cards.Add(deck[index]);
                deck.RemoveAt(index);
            }

            return cards;
        }

        public void Draw()
        {
            int totalChild = table.transform.childCount;
            if (subBoard.name == "SubBoardPlayer2")
            {
                handPlayerDesactivate = table.transform.GetChild(totalChild - 2).gameObject;
            }
            if (subBoard.name == "SubBoardPlayer1")
            {
                handPlayerDesactivate = table.transform.GetChild(totalChild - 1).gameObject;
            }
            GameObject deckZone = this.subBoard.transform.GetChild(0).gameObject;
            GameObject card = deckZone.transform.GetChild(0).gameObject;
            card.transform.SetParent(handPlayerDesactivate.transform, false);

        }

        #region Metodos auxiliares
        internal List<InfoCard> GetInfoCards(string sorce, List<Card> cardsInfo = null)
        {
            List <InfoCard> cards = new();
            GameObject zoneGame = null;
            cardsInfo = new();

            if (sorce == "hand") { zoneGame = HandPlayer; }
            else if (sorce == "graveyard") { zoneGame = SubBoard.transform.GetChild(7).gameObject; } 
            else if (sorce == "deck") { zoneGame = SubBoard.transform.GetChild(0).gameObject; }
            else if (sorce == "field") { zoneGame = SubBoard; }

            if(sorce =="field")
            {
                for (int k = 1; k < 4; k++)
                {
                    for (int i = 0; i < zoneGame.transform.GetChild(k).childCount; i++)
                    {
                        GameObject card = zoneGame.transform.GetChild(i).gameObject;
                        CardController cardController = card.GetComponent<CardController>();
                        cardsInfo.Add(cardController.infoCard);

                        if (cardController != null)
                        {
                            cards.Add(GetInfoCard(cardController.infoCard));
                        }
                    }
                }
            }
            else 
            {
                for (int i = 0; i < zoneGame.transform.childCount; i++) 
                {
                    GameObject card = zoneGame.transform.GetChild (i).gameObject;
                    CardController cardController = card.GetComponent<CardController>();
                    cardsInfo.Add(cardController.infoCard);

                    if (cardController != null)
                    {
                        cards.Add(GetInfoCard(cardController.infoCard));
                    }
                }
            }
            return cards;
        }
        private InfoCard GetInfoCard(Card infocard)
        {
            if (infocard is CardDataUnit unit)
            {
                return new InfoCard() { IdCard = unit.IdCard,Power = unit.OriginPower,Faction =unit.Faction,Name = unit.Name,Range = unit.DropZone,Type = (unit.Type != "hero")?"plata" : "oro"};
            }
            else if(infocard is CardDataClimate climate)
            {
                return new InfoCard() { IdCard = climate.IdCard, Name = climate.Name, Range = climate.AfectationZone, Type = "clima",Power = climate.Afectation};
            }
            else if (infocard is CardDataIncrease increase)
            {
                return new InfoCard() { IdCard = increase.IdCard, Name = increase.Name, Type = "aumento", Power = increase.Increase };
            }
            else if (infocard is CardDataLeader leader)
            {
                return new InfoCard() { IdCard = leader.IdCard, Name = leader.Name, Type = "lider",Faction = leader.Faction};
            }

            return new();
        }
        internal List<GameObject> CardsOfUnity(string source,out GameObject gameObject)
        {
            List<GameObject> cards = new();
            GameObject zoneGame = null;

            if (source == "hand") { zoneGame = HandPlayer; }
            else if (source == "graveyard") { zoneGame = SubBoard.transform.GetChild(7).gameObject; }
            else if (source == "deck") { zoneGame = SubBoard.transform.GetChild(0).gameObject; }
            else if (source == "field") { zoneGame = SubBoard; }

            if (source == "field")
            {
                for (int k = 1; k < 4; k++)
                {
                    for (int i = 0; i < zoneGame.transform.GetChild(k).childCount; i++)
                    {
                        GameObject card = zoneGame.transform.GetChild(i).gameObject;
                        cards.Add(card);
                    }
                }
            }
            else
            {
                for (int i = 0; i < zoneGame.transform.childCount; i++)
                {
                    GameObject card = zoneGame.transform.GetChild(i).gameObject;
                    cards.Add(card);
                }
            }
            gameObject = zoneGame;
            return cards;

        }
        #endregion

    }
}