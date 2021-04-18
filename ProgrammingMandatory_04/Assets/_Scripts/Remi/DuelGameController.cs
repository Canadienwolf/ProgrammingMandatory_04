using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuelGameController : MonoBehaviour
{
    public Text statusText;

    public float memorizeTime = 10f;
    public bool canDoTimer;

    private void Start()
    {
        statusText.text = "";
    }

    public void _StartCountdown()
    {
        GameObject.Find("Button_Start").SetActive(false);
        
        transform.Find("Placeholder (1)").GetComponent<DuelCardToSpawn>().RevealCardCollection();
        transform.Find("Placeholder (2)").GetComponent<DuelCardToSpawn>().RevealCardCollection();
        transform.Find("Placeholder (3)").GetComponent<DuelCardToSpawn>().RevealCardCollection();
        transform.Find("Placeholder (4)").GetComponent<DuelCardToSpawn>().RevealCardCollection();
        transform.Find("Placeholder (5)").GetComponent<DuelCardToSpawn>().RevealCardCollection();

        canDoTimer = true;
    }

    private void Update()
    {
        if (canDoTimer)
        {
            memorizeTime -= Time.deltaTime;
            statusText.text = "Seconds left to memorize: " + memorizeTime.ToString("F0");

            if (memorizeTime <= 0)
            {
                canDoTimer = false;
                memorizeTime = 0f;
                
                transform.Find("Placeholder (1)").GetComponent<DuelCardToSpawn>().HideCardCollection();
                transform.Find("Placeholder (2)").GetComponent<DuelCardToSpawn>().HideCardCollection();
                transform.Find("Placeholder (3)").GetComponent<DuelCardToSpawn>().HideCardCollection();
                transform.Find("Placeholder (4)").GetComponent<DuelCardToSpawn>().HideCardCollection();
                transform.Find("Placeholder (5)").GetComponent<DuelCardToSpawn>().HideCardCollection();
                
                statusText.text = "Dealer, pick a card from the collection!";
            }
        }
    }
}
