using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BettingSystem : MonoBehaviour
{
    private int startingCash;
    
    public int cashAmount;
    public Text CashAmountText;
    public Text betValueText;
    public GameObject notEnoughMoneyText;
    private int betAmount;
    private int currentCash;

    //-----Numbers from Sindre-----
    public int poolValue;

    //public Text betAmount;

    private void Awake()
    {
        if (startingCash == 0)
        {
            startingCash = 5;
            cashAmount = startingCash;
        }
        CashAmountText.text = cashAmount.ToString();
    }

    public void betNow()
    {

        betAmount = int.Parse(betValueText.text);
        currentCash = int.Parse(CashAmountText.text);

        if (betAmount < currentCash)
        {
            currentCash = currentCash - betAmount;
            CashAmountText.text = currentCash.ToString();
        }
        else
        {
            notEnoughMoneyText.SetActive(true);
        }
    }
    
    public void iWin(int winAmout)
    {
        currentCash = currentCash + winAmout;
    }

    public void addMoney()
    {
        cashAmount += 5;
    }

    public void iLose()
    {
        
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
