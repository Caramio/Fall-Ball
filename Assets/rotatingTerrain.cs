using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingTerrain : MonoBehaviour
{
    private float rotationSpeed;
    void Start()
    {
        rotationSpeed = Random.Range(35, 70);   
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed , Space.Self);

       
    }
}
