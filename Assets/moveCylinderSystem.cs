using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCylinderSystem : MonoBehaviour
{

    private float moveSpeed = 25f;

    private Rigidbody cylinderSystemBody;

    // Start is called before the first frame update
    void Start()
    {
        cylinderSystemBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

 
        //moveSystemUp();

        

    }

    private void FixedUpdate()
    {
        moveCylinderUp();
    }


    private void moveSystemUp()
    {
        //Use the movespeed from the gameControl class to sync both cylinder systems speed

        /*
        this.transform.position = new Vector3(this.transform.position.x,
            Mathf.Lerp(this.transform.position.y, this.transform.position.y + 1f, Time.deltaTime * gameControl.cylinderMoveSpeed), this.transform.position.z);
        */


    }

    private void moveCylinderUp()
    {

        cylinderSystemBody.velocity = new Vector3(0f, gameControl.cylinderMoveSpeed, 0f);


    }

    


}
