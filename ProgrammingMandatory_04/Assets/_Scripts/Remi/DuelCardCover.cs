using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class DuelCardCover : MonoBehaviour
{
    private float revealTime = 1f;
    public bool stayRevealed;
    public bool isRevealed;

    private DuelGameController dgc;

    private void Start()
    {
        dgc = FindObjectOfType<DuelGameController>();
    }

    public void _RevealCard()
    {
        isRevealed = true;
        
        if (transform.parent.GetChild(0).name == dgc.chosenCard)
        {
            dgc.CorrectCard();
            stayRevealed = true;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isRevealed)
        {
            revealTime -= Time.deltaTime;
            GetComponent<Image>().enabled = false;

            if (!stayRevealed)
            {
                if (revealTime <= 0f)
                {
                    GetComponent<Image>().enabled = true;
                    revealTime = 1f;
                    isRevealed = false;
                }
            }
        }
    }
}
