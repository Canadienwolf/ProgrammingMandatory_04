using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuelCardToSpawn : MonoBehaviour
{
    public GameObject CardCover;
    public GameObject[] Cards;

    public void RevealCardCollection()
    {
        var cardRevealInstance = Instantiate (Cards[Random.Range(0,Cards.Length)], transform.position, transform.rotation);
        cardRevealInstance.transform.SetParent(transform, false);
        cardRevealInstance.name = cardRevealInstance.name.Replace("(Clone)", "");
    }

    public void HideCardCollection()
    {
        var cardCoverInstance = Instantiate(CardCover, transform.position, transform.rotation);
        cardCoverInstance.transform.SetParent(transform, false);
    }
}
