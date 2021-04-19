using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuelCardToSpawn : MonoBehaviour
{
    public GameObject CardCover;
    public GameObject[] Cards;
    
    // Start is called before the first frame update
    void Start()
    {
        // var cardCoverInstance = Instantiate(CardCover, transform.position, transform.rotation);
        // cardCoverInstance.transform.SetParent(transform, false);
    }

    public void RevealCardCollection()
    {
        var cardRevealInstance = Instantiate (Cards[Random.Range(0,Cards.Length)], transform.position, transform.rotation);
        cardRevealInstance.transform.SetParent(transform, false);
        cardRevealInstance.name = cardRevealInstance.name.Replace("(Clone)", "");
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
