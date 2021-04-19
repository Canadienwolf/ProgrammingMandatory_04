using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomMovementsScript : MonoBehaviour
{
    public GameObject[] cards;

    public GameObject winningText;

    private string[] winString = { "Spade", "Heart", "Diamond", "Clover" };
    // Start is called before the first frame update
    void Start()
    {
        winningText.SetActive(false);
        cards = GameObject.FindGameObjectsWithTag("Cards2");
        //MoveCards(); call it to move the cards!
    }


    public void MoveCards()
    {
        int i = Random.RandomRange(0,4);
        cards[i].transform.position = new Vector3(cards[i].transform.position.x -0.45f, cards[i].transform.position.y, cards[i].transform.position.z);
        if (cards[i].transform.position.x <=-1.3f )
        {
            winningText.GetComponent<Text>().text = winString[i].ToString();
            winningText.SetActive(true);
            
        }
    }
}
