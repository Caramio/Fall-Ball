using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControl : MonoBehaviour
{
    
    //Reset the position to not get floating point errors eventually
    private float resetPositionTimer = 0f;

    public static float cylinderMoveSpeed = 20f;



    //Cylinder Systems
    public GameObject cylinderSystemOne, cylinderSystemTwo,fallingBall;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cylinderMoveSpeed += Time.deltaTime / 5;

        

        //Increase the timer
        resetPositionTimer += Time.deltaTime;
        //CONTINUE HERE------------
        if(resetPositionTimer >= 5f)
        {

            resetPositionTimer = 0f;
        }



    }
}
