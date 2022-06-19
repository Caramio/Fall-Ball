using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public GameObject ballObject;

    Vector3 ballTransform;

    void Start()
    {
        ballTransform = ballObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 ballTransform = ballObject.transform.position;

        this.transform.position = new Vector3(ballTransform.x, ballTransform.y + 15f, ballTransform.z);

    }
}
