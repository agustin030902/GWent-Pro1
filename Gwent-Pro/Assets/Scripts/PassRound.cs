using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.Net.Mime.MediaTypeNames;

public class PassRound : MonoBehaviour
{
    private GameObject effectLeaderPanel;
    private UnityEngine.UI.Image imageEffectLeaderPanel;
    private GameObject leader;
    private GameObject table;
    private CardDataLeader dataLeader;
    private GameObject finishRoundPanel;
    private UnityEngine.UI.Image imageFinishRoundPanel;
    private TMP_Text text;
    private GameObject board;
    private GameController gameController;

    private void OnEnable()
    {
        table = GameObject.Find("Table");
        effectLeaderPanel = GameObject.Find("EffectLeaderPanel");
        imageEffectLeaderPanel = effectLeaderPanel.GetComponent<UnityEngine.UI.Image>();
        board = GameObject.Find("Board");
        gameController = board.GetComponent<GameController>();
        finishRoundPanel = GameObject.Find("FinalizateRoundPanel");
        imageFinishRoundPanel = finishRoundPanel.GetComponent<UnityEngine.UI.Image>();
    }

    public void OnClick()
    {
        leader = (table.transform.rotation.z == 0) ? GameObject.Find("SubBoardPlayer1").transform.GetChild(8).GetChild(0).gameObject : GameObject.Find("SubBoardPlayer2").transform.GetChild(8).GetChild(0).gameObject;
        print(leader.name);
        CardController controller = leader.GetComponent<CardController>();  
        dataLeader = (CardDataLeader)controller.infoCard;
        if (!dataLeader.IsActivateEffects)
        {
            for (int i = 0; i < effectLeaderPanel.transform.childCount; i++)
            {
                effectLeaderPanel.transform.GetChild(i).gameObject.SetActive(true);
            }
            imageEffectLeaderPanel.enabled = true;
        }
        else
        {
            ActivateFinishPanel();
        }
    }
    private void ActivateFinishPanel()
    {
        text = finishRoundPanel.transform.GetChild(1).gameObject.GetComponent<TMP_Text>();
        for (int i = 0; i < finishRoundPanel.transform.childCount; i++)
        {
            finishRoundPanel.transform.GetChild(i).gameObject.SetActive(true);
        }
        imageFinishRoundPanel.enabled = true;
        if (table.transform.rotation.z == 1)
        {
            string info = "Player2 ha terminado su ronda";
            text.text = info;
            gameController.RoundNumberPlayer2++;
        }
        else
        {
            string info = "Player1 ha terminado su ronda";
            text.text = info;
            gameController.RoundNumberPlayer1++;
        }
    }

}
