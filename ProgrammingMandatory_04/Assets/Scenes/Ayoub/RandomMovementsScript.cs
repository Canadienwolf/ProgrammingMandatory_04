using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovementsScript : MonoBehaviour
{
    public GameObject[] cards;
    // Start is called before the first frame update
    void Start()
    {
        cards = GameObject.FindGameObjectsWithTag("Cards2");
        //MoveCards(); call it to move the cards!
    }


    public void MoveCards()
    {
        int i = Random.RandomRange(0,4);
        cards[i].transform.position = new Vector3(cards[i].transform.position.x -0.5f, cards[i].transform.position.y, cards[i].transform.position.z);
    }
}
