using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuelCardToSpawn : MonoBehaviour
{
    public GameObject CardCover;
    public GameObject[] Cards;

    public GameObject dealerDeck;
    
    // Start is called before the first frame update
    void Start()
    {
        dealerDeck.SetActive(false);
        var cardCoverInstance = Instantiate(CardCover, transform.position, transform.rotation);
        cardCoverInstance.transform.SetParent(transform, false);
    }

    public void RevealCardCollection()
    {
        var cardActualInstance = Instantiate (Cards[Random.Range(0,Cards.Length)], transform.position, transform.rotation);
        cardActualInstance.transform.SetParent(transform, false);
        
        var CardActualInstanceDealer = Instantiate(cardActualInstance, new Vector3(0, -350, 0), transform.rotation);
        CardActualInstanceDealer.transform.SetParent(dealerDeck.transform, false);
        CardActualInstanceDealer.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public void HideCardCollection()
    {
        transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("BackColor_Blue");
        dealerDeck.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
