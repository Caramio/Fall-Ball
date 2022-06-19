using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class uiButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Play the game
    public void playButton()
    {

        SceneManager.LoadScene(1);


    }

    //Play again after failing
    public void playAgainButton()
    {

        scoreChanger.scoreNumber = 0;
        SceneManager.LoadScene(1);

    }


    
}
