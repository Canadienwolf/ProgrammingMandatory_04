using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConnectionHandler : NetworkBehaviour
{
    public static event Action<int> onUpdatePlayerAmount;
    public static int playerAmount;

    public InGameNetworkHandler handler;

    void Start()
    {
        playerAmount++;
        onUpdatePlayerAmount?.Invoke(playerAmount);

        if (isLocalPlayer) 
        {
            handler = FindObjectOfType<InGameNetworkHandler>();
            handler.handler = this;
        }
    }

    void OnDestroy()
    {
        playerAmount--;
        onUpdatePlayerAmount?.Invoke(playerAmount);
    }

    public void ClientAddBet(int amount)
    {
        CmdAddBet(amount);
    }

    [Command]
    public void CmdAddBet(int amount)
    {
        RpcAddBet(amount);
    }

    [ClientRpc]
    public void RpcAddBet(int amount)
    {
        handler.bettingSystem.poolValue += amount;
    }
}
