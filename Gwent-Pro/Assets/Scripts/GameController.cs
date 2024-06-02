using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject SubBoard;
    public GameObject HandPlayer;
    public GameObject CardBlack;
    public List<GameObject> Deck1;
    public List<GameObject> Deck2;
    public GameObject leaderPlayer1;
    public GameObject leaderPlayer2;
    private GameObject panelRoundFinish;
    private GameObject textPanel;
    private GameObject leaderCardPlayer1;
    private GameObject leaderCardPlayer2;


    private CardController cardController;
    private Player player1;
    private Player player2;
    private GameObject table;
    private TMP_Text textRoundFinish;

    private bool isSummondCardInTurn = true;
    private bool isFinishRound2 = false;
    private bool isFinishRound1 = false;
    private bool initializePlayer1 = false;
    private bool initializePlayer21 = false;
    private bool controllerPlayer2 = false;
    private int turnNumberPlayer1 = 1;
    private int turnNumberPlayer2 = 1;
    private int roundNumberPlayer1 = 1;
    private int roundNumberPlayer2 = 1;
    private int cardsSelected = 0;
    private int[] playerVictory;
    private int indexDrawInitial = 0;
    private bool checkPoint = false;
    public Player Player1 { get => player1; set => player1 = value; }
    public Player Player2 { get => player2; set => player2 = value; }
    public int TurnNumberPlayer1 { get => turnNumberPlayer1; set => turnNumberPlayer1 = value; }
    public int TurnNumberPlayer2 { get => turnNumberPlayer2; set => turnNumberPlayer2 = value; }
    public int RoundNumberPlayer1 { get => roundNumberPlayer1; set => roundNumberPlayer1 = value; }
    public int RoundNumberPlayer2 { get => roundNumberPlayer2; set => roundNumberPlayer2 = value; }
    public bool IsSummondCardInTurn { get => isSummondCardInTurn; set => isSummondCardInTurn = value; }
    public bool IsFinishRound2 { get => isFinishRound2; set => isFinishRound2 = value; }
    public bool IsFinishRound1 { get => isFinishRound1; set => isFinishRound1 = value; }
    public bool InitializePlayer1 { get => initializePlayer1; set => initializePlayer1 = value; }
    public bool InitializePlayer21 { get => initializePlayer21; set => initializePlayer21 = value; }
    public int CardsSelected { get => cardsSelected; set => cardsSelected = value; }
    public int[] PlayerVictory { get => playerVictory; set => playerVictory = value; }
    public bool CheckPoint { get => checkPoint; set => checkPoint = value; }

    private void Awake()
    {
        playerVictory = new int[3];
        table = GameObject.Find("Table");
        GameObject board = GameObject.Find("Board");
        GameObject subBoardPlayer1 = Instantiate(SubBoard,board.transform);
        GameObject subBoardPlayer2 = GameObject.Find("SubBoardPlayer2");
        GameObject player2Hand = GameObject.Find("Player2 Hand");
        subBoardPlayer1.name = "SubBoardPlayer1";
        board.transform.GetChild(0).gameObject.SetActive(true);
        GameObject player1Hand = Instantiate(HandPlayer,table.transform);
        player1Hand.name = "Player1 Hand";
        leaderCardPlayer1 = Instantiate(leaderPlayer1,subBoardPlayer1.transform.GetChild(8),true);
        leaderCardPlayer2 =  Instantiate(leaderPlayer2,subBoardPlayer2.transform.GetChild(8),!true);


        Player1 = new(subBoardPlayer1,Deck1,player1Hand);
        Player2 = new(subBoardPlayer2,Deck2,player2Hand);

        Player1.Initialize();
        InvokeRepeating(nameof(ActivateMethodDrawInitial1), 0.45f, 0.3f);
        Invoke(nameof(InitializateTwoCards),3+0.45f);

        Player2.HandPlayer.SetActive(false);
        player2.Initialize();
        for(int i = 0; i < 10; i++)
        {
            player2.Draw();
        }

    }

    private void Start()
    {
        panelRoundFinish = GameObject.Find("PlayersFinishRoundPanel");
        textPanel = panelRoundFinish.transform.GetChild(0).gameObject;
        textRoundFinish = textPanel.GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (isFinishRound1 && isFinishRound2 )
        {
            IsFinishRound1 = false;
            IsFinishRound2 = false;
            player1.RoundPts[RoundNumberPlayer1 - 2] = AssingRoundPts(player1);
            player2.RoundPts[RoundNumberPlayer2 - 2] = AssingRoundPts(player2);

            if (AssingRoundPts(player1) > AssingRoundPts(player2))
            {
                playerVictory[RoundNumberPlayer1 - 2] = 1;
            }
            else if (AssingRoundPts(player1) < AssingRoundPts(player2))
            {
                playerVictory[RoundNumberPlayer1 - 2] = 2;
            }
            else
            {
                playerVictory[RoundNumberPlayer1 - 2] = 0;
            }



            InitializePanelPoint(player1.RoundPts[RoundNumberPlayer1 - 2], player2.RoundPts[RoundNumberPlayer2 - 2]);

            SendCardsCemetery(player1);
            SendCardsCemetery(player2);
            

            if (RoundNumberPlayer1 == RoundNumberPlayer2 && RoundNumberPlayer2 == 2 || RoundNumberPlayer2 == 3)
            {
                for(int i = 0;i< 2 ;i++)
                {
                    player1.Draw();
                    player2.Draw();
                }
            }
           
        }
        if (table.transform.rotation.z == 1 ) // turno de player2
        {
            HideHand(Player1);
            ViewHand(Player2);

            if (!controllerPlayer2 && ((1 == turnNumberPlayer2 && turnNumberPlayer1 == 2 && roundNumberPlayer1 == roundNumberPlayer2 && roundNumberPlayer2 == 1) || roundNumberPlayer1 - roundNumberPlayer2 == 1) && !InitializePlayer21)
            {
                InitializateTwoCards();
                controllerPlayer2 = true;
            }
            else if(InitializePlayer21 && controllerPlayer2)
            {
                for(int i = 0;i < CardsSelected;i++)
                {
                    player2.Draw();
                }
                InitializePlayer21 = false;
            }
            
        }
        if (table.transform.rotation.z == 0 ) // turno de player1
        {
            HideHand(Player2);
            ViewHand(Player1);
            if(initializePlayer1)
            {
                for (int i = 0; i < CardsSelected; i++)
                {
                    player1.Draw();
                }
                initializePlayer1 = false;  
            }
        }
    }

    private void ActivateMethodDrawInitial1()
    {
        if (indexDrawInitial == 10) 
        {
            CancelInvoke(nameof(ActivateMethodDrawInitial1));
        }
        else
        {
            Player1.Draw();
            indexDrawInitial++;
            return;
        }
    }
    private void ActivateMethodDrawInitial2()
    {
        if (indexDrawInitial < 20)
        {
            Player2.Draw();
            indexDrawInitial++;
            return;
        }
        else
        {
            CancelInvoke(nameof(ActivateMethodDrawInitial2));
        }
    }
    private void HideHand(Player player)
    {
        player.HandPlayer.SetActive(false);
        //int cardCount = player.HandPlayer.transform.childCount;
        //for (int i = 0; i < cardCount; i++)
        //{
        //    player.HandPlayer.transform.GetChild(i).gameObject.SetActive(false);
        //    Instantiate(CardBlack, player.HandPlayer.transform);
        //}

    }
    private void ViewHand(Player player)
    {
        player.HandPlayer.SetActive(true);
        //int cardCount = player.HandPlayer.transform.childCount/2;
        //for(int i = 0; i< player.HandPlayer.transform.childCount; i++) 
        //{
        //    if (player.HandPlayer.transform.childCount > cardCount)
        //    {
        //        Destroy(player.HandPlayer.transform.GetChild(player.HandPlayer.transform.childCount - 1).gameObject);
        //    }
        //    player.HandPlayer.transform.GetChild(i).gameObject.SetActive(false);

        //}

    }
    private void InitializePlayer2()
    {
        indexDrawInitial = 0;
        player2.Initialize();
        InvokeRepeating(nameof(ActivateMethodDrawInitial2), 0,0.1f);
    }
    private void InitializateTwoCards()
    {
        GameObject twoCardsPanel = GameObject.Find("TwoCardsReturnPanel");
        Image imagePanel = twoCardsPanel.GetComponent<Image>();
        imagePanel.enabled = true;
        for (int i = 0; i < twoCardsPanel.transform.childCount; i++)
        {
            twoCardsPanel.transform.GetChild(i).gameObject.SetActive(true);
        }

    }
    private  int AssingRoundPts(Player player)
    {
        int sum = 0;
        for (int j = 1; j <= 3; j++)
        {
            for (int i = 0; i < player.SubBoard.transform.GetChild(j).childCount; i++)
            {
                GameObject card = player.SubBoard.transform.GetChild(j).GetChild(i).gameObject;
                cardController = card.GetComponent<CardController>();
                if(cardController.infoCard is CardDataUnit)
                {
                    CardDataUnit unit = (CardDataUnit)cardController.infoCard;
                    sum += unit.Power;
                }
            }
        }
        return sum;
    }
    private void InitializePanelPoint(int ptsPlayer1,int ptsPlayer2)
    {
        Image imagePanel = panelRoundFinish.GetComponent<Image>();
        imagePanel.enabled = true;

        for(int i = 0;i<panelRoundFinish.transform.childCount ;i++)
        {
            panelRoundFinish.transform.GetChild(i).gameObject.SetActive(true); 
        }

        textRoundFinish.text = "resultado de la ronda"+(RoundNumberPlayer1-1)+": "+'\n'+'\n'+"player1: " + ptsPlayer1+'\n'+'\n'+"player2: " +ptsPlayer2;


    }
    private void SendCardsCemetery(Player player)
    {
        GameObject leaderCard = (table.transform.rotation.z == 1 ? leaderCardPlayer2 : leaderCardPlayer1);
        for (int j = 1; j <= 6; j++)
        {
            for (int i = 0; i < player.SubBoard.transform.GetChild(j).childCount; i++)
            {
                GameObject card = player.SubBoard.transform.GetChild(j).GetChild(i).gameObject;
                cardController = card.GetComponent<CardController>();
                if(!cardController.IsSaveLeader)
                {
                    MonoBehaviour effectCard = card.GetComponent<MonoBehaviour>();
                    GameObject cardInCemetery = Instantiate(card, new Vector2(0, 0), Quaternion.identity);
                    cardInCemetery.transform.SetParent(player.SubBoard.transform.GetChild(7), false);
                    Destroy(card);
                    cardController = cardInCemetery.GetComponent<CardController>();
                    cardController.enabled = false;
                    if (effectCard is not Image)
                    {
                        effectCard.enabled = false;
                    }
                }
                else if(cardController.IsSaveLeader)
                {
                    cardController.IsSaveLeader = false;
                }
            }
        }
    }
}
