using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class scoreChanger : MonoBehaviour
{
    public Text scoreText;


    //Score increasing integer
    public static int scoreNumber = 0;


    //Timer to increase score
    private float scoreTimer = 0.5f;
    private float scoreCounter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Increase the score by one each second
        scoreCounter += Time.deltaTime;

        if(scoreCounter >= scoreTimer)
        {
            scoreNumber += 1;
            scoreCounter = 0f;
        }
        //

        scoreText.text = scoreNumber.ToString();

    }
}
