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
        // var cardCoverInstance = Instantiate(CardCover, transform.position, transform.rotation);
        // cardCoverInstance.transform.SetParent(transform, false);
    }

    public void RevealCardCollection()
    {
        var cardRevealInstance = Instantiate (Cards[Random.Range(0,Cards.Length)], transform.position, transform.rotation);
        cardRevealInstance.transform.SetParent(transform, false);
        
        var cardRevealDealerInstance = Instantiate(cardRevealInstance, new Vector3(0, -350, 0), transform.rotation);
        cardRevealDealerInstance.transform.SetParent(dealerDeck.transform, false);
        cardRevealDealerInstance.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        cardRevealDealerInstance.GetComponent<Button>().onClick.AddListener(this.ButtonClicked);
    }
    public void ButtonClicked() 
    {
        PlayerPrefs.SetString("PrefsDealersChoice", transform.GetChild(0).name.Replace("(Clone)", ""));
        print("Dealer has chosen card: " + PlayerPrefs.GetString("PrefsDealersChoice"));
        
        GameObject.Find("DealerDeck").SetActive(false);
        GameObject.Find("Text_GameStatus").GetComponent<Text>().text =
            transform.GetChild(0).name.Replace("(Clone)", "") + " was chosen!. \nP1 or P2, Quick find the blue card!";
    }

    public void HideCardCollection()
    {
        // transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("BackColor_Blue");
        
        var cardCoverInstance = Instantiate(CardCover, transform.position, transform.rotation);
        cardCoverInstance.transform.SetParent(transform, false);
        
        dealerDeck.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
