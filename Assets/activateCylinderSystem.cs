using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateCylinderSystem : MonoBehaviour
{

    public GameObject cylinderSystem;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Activate the cylinder system
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            //Activate the give cylinder system
            cylinderSystem.SetActive(true);

        }

    }
}
