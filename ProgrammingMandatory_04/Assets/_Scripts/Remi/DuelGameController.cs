using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DuelGameController : MonoBehaviour
{
    public Text statusText;

    public float memorizeTime = 5f;
    public bool canDoTimer;

    private void Start()
    {
        statusText.text = "";
    }
    
    public string[] GetDuelerChildrenNames(Transform trans)
    {
        List<string> _returnValue = new List<string>();

        foreach (Transform item in trans)
        {
            _returnValue.Add(item.gameObject.name);
        }

        return _returnValue.ToArray();
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
                
                statusText.text = "Dealer is choosing a card...";
                
                int childIndex = Random.Range(0, GameObject.Find("DealerDeck").gameObject.transform.childCount);
                
                print(childIndex);

                // var randomDealIndex = Random.Range(0, GameObject.Find("DealerDeck").gameObject.transform.name.childCount);
                // randomDealIndex =
                //     PlayerPrefs.SetString("PrefsDealersChoice", transform.GetChild(0).name.Replace("(Clone)", ""));
            }
        }
        
    }
}
