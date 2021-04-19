using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConnectionHandler : MonoBehaviour
{
    public static event Action<int> onUpdatePlayerAmount;
    public static int playerAmount;

    void Start()
    {
        playerAmount++;
        onUpdatePlayerAmount?.Invoke(playerAmount);
    }

    void OnDestroy()
    {
        playerAmount--;
        onUpdatePlayerAmount?.Invoke(playerAmount);
    }
}
