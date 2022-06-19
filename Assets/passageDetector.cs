using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passageDetector : MonoBehaviour
{
    public GameObject cylinderSystem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball Outer")
        {
            

            if (cylinderSystem.activeInHierarchy == false)
            {

                cylinderSystem.SetActive(true);

                cylinderSystem.GetComponent<generateCylinderOrder>().orderCylinderSystem();

            }
            else
            {

                cylinderSystem.GetComponent<generateCylinderOrder>().orderCylinderSystem();

            }

            

        }
    }
}
