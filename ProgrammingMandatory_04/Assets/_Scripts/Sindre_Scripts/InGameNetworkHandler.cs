using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class InGameNetworkHandler : NetworkBehaviour
{
    public static bool IsServer;

    public BettingSystem bettingSystem;
    public GameObject waitScreen, betScreen;
    public Text yourMoneyTxt;

    public PlayerConnectionHandler handler;

    void Start()
    {
        IsServer = isServer;
    }

    void Update()
    {
        yourMoneyTxt.text = "Score: " + EnterUserName.userScore.ToString();
    }

    public void StartGame()
    {
        if (!IsServer) return;
        RpcStartGame();
    }

    [ClientRpc]
    public void RpcStartGame()
    {
        waitScreen.SetActive(false);
        betScreen.SetActive(true);
    }

    public void EndTurn(int winIndex)
    {
        if (!IsServer) return;

        RpcEndTurn(winIndex);
    }

    [ClientRpc]
    public void RpcEndTurn(int winIndex)
    {
        bettingSystem.CheckWin(winIndex);
    }
}
