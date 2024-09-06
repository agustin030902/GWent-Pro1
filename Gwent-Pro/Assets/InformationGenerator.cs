using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gwent_Compiler;
using Gwent_Game;
using System;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
internal static class InformationGenerator
{
    public static GameObject prefabCard = GameObject.FindWithTag("prefab");
    static Player Player1 { get; set; }
    static Player Player2 { get; set; }
    static readonly string[] strings = new string[] {"hand","otherHand","field","otherField","deck","otherDeck","board" };
    private static readonly GameObject Table = GameObject.Find("table");
    internal static List<InfoCard> cards = new();
    internal static Player PlayerContext ()
    {
        if(Table.transform.rotation.z == 0 ) {  return Player1; }
        else if (Table.transform.rotation.z == 1) { return Player2; }

        return null;
    }
    internal static (GameObject,List<(GameObject,InfoCard)>) PlayerSelectorSource(string source)
    {
        Player player;
        List<(GameObject, InfoCard)> result = new();
        GameObject zone;

        if (Table.transform.rotation.z == 0 && strings.Contains(source) && !source.Contains("other")) { player = Player1; }
        else if (Table.transform.rotation.z == 1 && strings.Contains(source) && source.Contains("other")) { player = Player1; source = source[4..].ToLower(); }
        else if (Table.transform.rotation.z == 0 && strings.Contains(source) && source.Contains("other")) { player = Player2; }
        else if (Table.transform.rotation.z == 1 && strings.Contains(source) && !source.Contains("other")) { player = Player2; source = source[4..].ToLower(); }
        else { throw new Exception("'"+source+"' "); }
        List<InfoCard> infoCards = player.GetInfoCards(source);
        List<GameObject> cardsUnity= player.CardsOfUnity(source,out zone);

        for (int i = 0;i < infoCards.Count;i++)
        {
            result.Add((cardsUnity[i], infoCards[i]));
        }

        return (zone,result);
    }
    private static Card CardUnity(InfoCard infoCard)
    {
        if(infoCard.Type == "Oro")
        {
            CardDataUnit card = new("hero",infoCard.Range,(int)infoCard.Power,infoCard.Faction,(int)infoCard.Power);
            return card;
        }
        else if (infoCard.Type == "Plata")
        {
            CardDataUnit card = new("plata", infoCard.Range, (int)infoCard.Power, infoCard.Faction, (int)infoCard.Power);
            return card;
        }
        else if (infoCard.Type == "Clima")
        {
            CardDataClimate card = new(infoCard.Range, (int)infoCard.Power)
            {
                Name = infoCard.Name
            };
            return card;
        }
        else if (infoCard.Type == "Aumento")
        {
            CardDataIncrease card = new((int)infoCard.Power)
            {
                Name = infoCard.Name
            };
            return card;
        }
        else if(infoCard.Type == "Lider")
        {
            CardDataLeader card = new(infoCard.Faction)
            {
                Name = infoCard.Name
            };
            return card;
        }
        return null;
    }
    internal static void CreateCard(SyntaxTree syntaxTree)
    {
        List<GameObject> cardList = new();
        Card cardInfoAux;

        try
        {
            cards = syntaxTree.ReadParse();
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }

        foreach (var card in cards)
        {
            cardInfoAux = InformationGenerator.CardUnity(card);
            CardController controller = prefabCard.GetComponent<CardController>();
            controller.infoCard = cardInfoAux;
            EffectCardUnity effectCardUnity = prefabCard.GetComponent<EffectCardUnity>();
            effectCardUnity.Effects = (card.Effects.Count > 0)? card.Effects: new();
            cardList.Add(prefabCard);
            Debug.Log(prefabCard.IsPrefabDefinition());
        }


        Debug.Log("La lista tiene "+cardList.Count);
        Debug.Log("La lista de la base de datos "+DataBaseScript.data.DataBase.List.Count);

        if ((DataBaseScript.data.DataBase.List.Count > 0)) { DataBaseScript.data.DataBase.List.AddRange(cardList); }
        else { DataBaseScript.data.DataBase.List = cardList; }


        //baseScript.DataBase.List.Clear();
        GameObject cardVisual = GameObject.Find("Main Camera").transform.GetChild(1).GetChild(0).GetChild(0).gameObject;

        //Debug.Log(cardVisual);

        foreach (var card in DataBaseScript.data.DataBase.List)
        {
            //card.transform.SetParent(cardVisual.transform,false);
            GameObject.Instantiate(card.transform, cardVisual.transform,false);
        }
    }


}
