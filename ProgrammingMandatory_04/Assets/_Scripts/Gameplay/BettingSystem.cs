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

    //public Text betAmount;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("CashAmount"))
        {
            getValues();
        }
        else
        {
            startingCash = 5;
            cashAmount = startingCash;
            setValues();
        }
        CashAmountText.text = cashAmount.ToString();
    }

    public void getValues()
    {
        cashAmount = PlayerPrefs.GetInt("CashAmount");
    }
    
    public void setValues()
    {
        PlayerPrefs.SetInt("CashAmount", cashAmount);
    }

    public void betNow()
    {
        
        //int betAmount = Convert.ToInt32(betValueText);
        //int.Parse(betValueText, System.Globalization.NumberStyles.Integer);
        //int betAmount = Convert.ToInt32(betValueText);
        //int betAmount = int.TryParse(betValueText);
        //betValueText.text = Convert.ToInt32(betAmount);
        //int.TryParse(betAmount);
        //betValueText.ToString();
        //int betAmount = int.Parse(betValueText);
        //System.Convert.ToInt32(betValueText, betAmount);

        int betAmount = int.Parse(betValueText.text);
        int currentCash = int.Parse(CashAmountText.text);

        if (betAmount < currentCash)
        {
            currentCash = currentCash - betAmount;
            CashAmountText.text = currentCash.ToString();
            PlayerPrefs.SetInt("CashAmount", currentCash);
        }
        else
        {
            notEnoughMoneyText.SetActive(true);
        }
        
        print(PlayerPrefs.GetInt("CashAmount"));
        
        //currentamountcash
    }

    private void Update()
    {
        //print(PlayerPrefs.GetInt("CashAmount"));
        
    }
}
    
