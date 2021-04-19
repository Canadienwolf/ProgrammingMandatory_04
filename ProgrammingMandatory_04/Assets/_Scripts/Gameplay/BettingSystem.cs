using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BettingSystem : MonoBehaviour
{
    public event Action<int> onResult;

    private int startingCash;
    
    public static int cashAmount;
    public Text CashAmountText;
    public InputField betValueInput;
    public GameObject notEnoughMoneyText;
    private int betAmount;
    private int currentCash;
    public GameObject outcomeObject;

    //-----Numbers from Sindre-----
    public int poolValue;
    public int betIndex = 0;

    //public Text betAmount;

    private void OnEnable()
    {
        if (startingCash == 0)
        {
            startingCash = 5;
            cashAmount = startingCash;
        }
        CashAmountText.text = cashAmount.ToString();
    }

    public void betNow(int _betIndex)
    {
        if (betValueInput.text == string.Empty) return;

        betIndex = _betIndex;
        betAmount = int.Parse(betValueInput.text);
        currentCash = int.Parse(CashAmountText.text);

        if (betAmount <= currentCash)
        {
            currentCash = currentCash - betAmount;
            CashAmountText.text = currentCash.ToString();
            FindObjectOfType<InGameNetworkHandler>().handler.ClientAddBet(betAmount);

            outcomeObject.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            notEnoughMoneyText.SetActive(true);
        }
    }

    public void CheckWin(int winIndex)
    {
        onResult?.Invoke(winIndex);
        if(winIndex == betIndex)
        {
            iWin(poolValue);
        }

        poolValue = 0;
    }
    
    public void iWin(int winAmout)
    {
        currentCash = currentCash + winAmout;
        EnterUserName.userScore += winAmout;
    }

    public static void addMoney()
    {
        cashAmount += 5;
    }
}
    



//int betAmount = Convert.ToInt32(betValueText);
//int.Parse(betValueText, System.Globalization.NumberStyles.Integer);
//int betAmount = Convert.ToInt32(betValueText);
//int betAmount = int.TryParse(betValueText);
//betValueText.text = Convert.ToInt32(betAmount);
//int.TryParse(betAmount);
//betValueText.ToString();
//int betAmount = int.Parse(betValueText);
//System.Convert.ToInt32(betValueText, betAmount);
