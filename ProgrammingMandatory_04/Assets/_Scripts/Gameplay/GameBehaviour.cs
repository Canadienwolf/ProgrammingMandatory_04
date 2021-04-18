using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameBehaviour : MonoBehaviour
{
    public bool testMode;
    
    private float Money;

    public GameObject DealersCardDeck;
    public GameObject DealersCard;

    public GameObject[] Cards;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (testMode)
        {
            Money = 1000;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Destroy(DealersCard);
            DealersCard = Cards[Random.Range(0, Cards.Length)];
            Instantiate(DealersCard,DealersCardDeck.transform);
            
            //DealersCard.transform.parent = GameObject.Find("DealersCard").transform;
        }
    }
}
