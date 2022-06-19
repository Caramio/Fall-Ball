using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ballCollisionChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Obstacle")
        {
            //Renew the initial cylinder generation bool
            generateCylinderOrder.firstGeneratorWasMade = false;
            generateCylinderOrder.firstConnectionWasMade = false;

            //Reset game speed
            gameControl.cylinderMoveSpeed = 10f;

            //Load the defeat scene

            SceneManager.LoadScene(2);

        }

    }

    

}
