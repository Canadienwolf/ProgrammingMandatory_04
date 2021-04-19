using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DuelGameController : MonoBehaviour
{
    public Text statusText;

    private float memorizeTime = 5f;
    public bool canDoTimer;


    private void Start()
    {
        statusText.text = "";
    }

    public List<GameObject> getListOfRevealedCards = new List<GameObject>(); 
    public string chosenCard;

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

                getListOfRevealedCards.Add( transform.Find("Placeholder (1)").GetChild(0).gameObject);
                getListOfRevealedCards.Add( transform.Find("Placeholder (2)").GetChild(0).gameObject);
                getListOfRevealedCards.Add( transform.Find("Placeholder (3)").GetChild(0).gameObject);
                getListOfRevealedCards.Add( transform.Find("Placeholder (4)").GetChild(0).gameObject);
                getListOfRevealedCards.Add( transform.Find("Placeholder (5)").GetChild(0).gameObject);
                
                
                chosenCard = getListOfRevealedCards[Random.Range(0, getListOfRevealedCards.Count)].gameObject.name;
                statusText.text = "Find the card: \n" + chosenCard;
            }
        }
    }

    public void CorrectCard()
    {
        statusText.text = "You won the duel \nby choosing the card: \n" + chosenCard;
    }
}
