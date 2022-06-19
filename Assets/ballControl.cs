using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControl : MonoBehaviour
{

    //movespeed for the ball
    public float moveSpeed;

    private Rigidbody ballBody;

    public Camera mainCamera;

    private Transform ballTransform;


    void Start()
    {
        ballBody = this.GetComponent<Rigidbody>();
        ballTransform = this.GetComponent<Transform>();

        Application.targetFrameRate = 60;
        
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(Application.targetFrameRate);

        //controlBall();

        


        //controlBallPC();

        //controlBallPCNonVel();

        //controlBallTouchScreen();

        //controlBallTouchScreenNonVel();
    }

    private void FixedUpdate()
    {

        if (ballBody.velocity.y > 0)
        {
            ballBody.velocity = new Vector3(ballBody.velocity.x, 0f, ballBody.velocity.z);
        }

        controlBallPCNonVel();

        //controlBallTouchScreenNonVel();
    }

    private bool analogAdjusted;
    private Vector3 analogSpot;

    private void controlBallPC()
    {
        if (Input.GetMouseButton(0))

        {

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (analogAdjusted == false)
            {
                analogSpot = ray.direction;
                analogAdjusted = true;
                Debug.Log(analogSpot);
            }



            

            Ray movingRay = mainCamera.ScreenPointToRay(Input.mousePosition);

            Vector3 analogDireciton = (movingRay.direction - analogSpot).normalized;

            Debug.DrawRay(Camera.main.transform.position, analogDireciton);


            ballBody.velocity = new Vector3(analogDireciton.x * moveSpeed , 0f, analogDireciton.z * moveSpeed);

            

           

            //Debug.Log(analogDireciton);


        }

        if (Input.GetMouseButtonUp(0))
        {
            

            analogAdjusted = false;

            ballBody.velocity = Vector3.zero;
        }


    }
      
    private void controlBallPCNonVel()
    {
        if (Input.GetMouseButton(0))

        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (analogAdjusted == false)
            {
                analogSpot = ray.direction;
                analogAdjusted = true;
                Debug.Log(analogSpot);
            }


            if (Input.mousePosition != analogSpot)
            {
                Ray movingRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                Vector3 analogDireciton = (movingRay.direction - analogSpot).normalized;

                Vector3 realDir = new Vector3(analogDireciton.x * Time.deltaTime * moveSpeed, 0f, analogDireciton.z * Time.deltaTime * moveSpeed);

                ballBody.MovePosition(ballTransform.position + realDir * moveSpeed);
            }

            //Debug.Log(analogDireciton);


        }

        if (Input.GetMouseButtonUp(0))
        {
            analogAdjusted = false;

            ballBody.velocity = Vector3.zero;
        }


    }
    
    public Material colorTest;
    public Material colorOrg;
    private void controlBallTouchScreen()
    {
        if (Input.touchCount > 0)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            //Adjust analogs spot on the screen
            if (analogAdjusted == false)
            {
                analogSpot = ray.direction;
                analogAdjusted = true;
            }


            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary)
            {

                
                Ray movingRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                Vector3 analogDireciton = (movingRay.direction - analogSpot).normalized;

                ballBody.velocity = new Vector3(analogDireciton.x * moveSpeed , 0f , analogDireciton.z * moveSpeed);


            }
            

            //Touch was ended
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {

                analogAdjusted = false;

                ballBody.velocity = Vector3.zero;


            }



        }
    }

    private void controlBallTouchScreenNonVel()
    {
        if (Input.touchCount > 0)
        {



            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            //Adjust analogs spot on the screen
            if (analogAdjusted == false)
            {
                analogSpot = ray.direction;
                analogAdjusted = true;
            }


            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary)
            {



                Ray movingRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                Vector3 analogDireciton = (movingRay.direction - analogSpot).normalized;

                Vector3 realDir = new Vector3(analogDireciton.x * Time.deltaTime * moveSpeed, 0f, analogDireciton.z * Time.deltaTime * moveSpeed);

                ballBody.MovePosition(ballTransform.position + realDir * moveSpeed);

            }

            //Touch was ended
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {




                analogAdjusted = false;

                ballBody.velocity = Vector3.zero;


            }



        }
    }

    private void controlBall()
    {

        // Controlling the ball with the arrow keys
        if (Input.GetKey(KeyCode.LeftArrow) && ballBody.velocity.x > -moveSpeed)
        {


            ballBody.velocity = new Vector3(ballBody.velocity.x - moveSpeed, ballBody.velocity.y, ballBody.velocity.z);

        }

        if (Input.GetKey(KeyCode.RightArrow) && ballBody.velocity.x < moveSpeed)
        {

            ballBody.velocity = new Vector3(ballBody.velocity.x + moveSpeed, ballBody.velocity.y, ballBody.velocity.z);

        }
        //----------------------------
        //----------------------------
        if (Input.GetKey(KeyCode.UpArrow) && ballBody.velocity.z < moveSpeed)
        {

            ballBody.velocity = new Vector3(ballBody.velocity.x, ballBody.velocity.y, ballBody.velocity.z + moveSpeed);

        }

        if (Input.GetKey(KeyCode.DownArrow) && ballBody.velocity.z > -moveSpeed)
        {

            ballBody.velocity = new Vector3(ballBody.velocity.x, ballBody.velocity.y, ballBody.velocity.z - moveSpeed);

        }


        //Reset velocity when the button is released
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {

            ballBody.velocity = new Vector3(0f, ballBody.velocity.y, 0f);

        }



    }
}
