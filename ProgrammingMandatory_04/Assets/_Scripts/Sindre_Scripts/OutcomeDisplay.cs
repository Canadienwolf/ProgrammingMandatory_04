using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class OutcomeDisplay : MonoBehaviour
{
    public BettingSystem bettingSystem;
    public InGameNetworkHandler handler;
    public Text poolAmountTxt;
    public Text waitingTxt;
    public GameObject seeResultBtn;
    public Text resultTxt;
    public GameObject bettingObj;

    private int winIndex = 0;
    public bool ended;

    void OnEnable()
    {
        ended = false;
        bettingSystem.onResult += DisplayResults;
    }

    void OnDisable() => bettingSystem.onResult -= DisplayResults;

    void Update()
    {
        poolAmountTxt.text = "Pool: " + bettingSystem.poolValue;

        if (handler.isServer && !ended)
            seeResultBtn.SetActive(true);
        else
            seeResultBtn.SetActive(false);
    }

    public void UpdateResults()
    {
        winIndex = Random.Range(0, 4);
        
        handler.EndTurn(winIndex);
    }

    public void DisplayResults(int _idx)
    {
        ended = true;
        resultTxt.gameObject.SetActive(true);
        string _winningCard = "";
        switch (_idx)
        {
            case 0:
                _winningCard = "Heart";
                break;
            case 1:
                _winningCard = "Clover";
                break;
            case 2:
                _winningCard = "Diamond";
                break;
            case 3:
                _winningCard = "Spade";
                break;
        }

        resultTxt.text = _winningCard;

        Invoke("BackToBetting", 3);
    }

    void BackToBetting()
    {
        resultTxt.gameObject.SetActive(false);
        seeResultBtn.SetActive(true);

        bettingObj.SetActive(true);
        gameObject.SetActive(false);
    }
}
