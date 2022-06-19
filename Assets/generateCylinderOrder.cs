using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class generateCylinderOrder : MonoBehaviour
{

    //List of possible cylinders
    public List<GameObject> cylindersList;
    //Final passage cylinder
    public GameObject finalPassageCylinder;
    //The very first cylinder that will be deleted after the first cylinder generation
    public GameObject firstCylinder;



    //Random starting cylinder number
    private int randomStartCylinder;

    //Random cylinder number to be added
    private int randomCylinderNumber;


 

    //Track the last cylinder
    private Transform previousCylinderBottom;





    //Passage point for the fruit passages to link the systems
    public GameObject fruitPassageOne;
    public GameObject fruitPassageTwo;

    //Check if the very first connection was made (starting at 0,0,0)
    public static bool firstConnectionWasMade = false;


    //Bool to check if the generation method was called once
    public static bool firstGeneratorWasMade;




    private void OnEnable()
    {
        //Check to see if the very first shuffle was called
        if (firstGeneratorWasMade == false)
        {
            
            orderCylinderSystem();
            firstGeneratorWasMade = true;

        }
    }


    void Start()
    {
        
        
        //------------------------

        // Only do the start method if this is the initial cylinder
        if (this.gameObject.name == "Cylinder System One")
        {
            //orderCylinders();
        }
        /*
        //Check to see if the very first shuffle was called
        if (firstGeneratorWasMade == false)
        {
            Debug.Log("Did this11111111111111111");
            orderCylinderSystem();
            firstGeneratorWasMade = true;
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void orderCylinderSystem()
    {
        //List of random numbers
        List<int> randomNumbersList = new List<int>();

        //Add numbers to the random numbers list
        randomNumbersList.Add(0);
        randomNumbersList.Add(1);
        randomNumbersList.Add(2);
        randomNumbersList.Add(3);

        

        //Pick a random cylinder to be the first one
        randomStartCylinder = Random.Range(0, cylindersList.Count);
        //Remove the number from the randomNumbersList
        randomNumbersList.Remove(randomStartCylinder);


        

        //Create the very first connection for the first cylinder system
        if(firstConnectionWasMade == false)
        {

            cylindersList[randomStartCylinder].GetComponent<connectionReferences>().connectionTop.position = firstCylinder.GetComponent<connectionReferences>().connectionBottom.position;

            //set the first previous cylinder bottom to use later in the loop
            previousCylinderBottom = cylindersList[randomStartCylinder].GetComponent<connectionReferences>().connectionBottom;

            firstConnectionWasMade = true;

        }
        else
        {

            if(this.gameObject.name == "Cylinder System One")
            {

                previousCylinderBottom = fruitPassageTwo.GetComponent<connectionReferences>().connectionBottom;

                cylindersList[randomStartCylinder].GetComponent<connectionReferences>().connectionTop.position = previousCylinderBottom.position;

                previousCylinderBottom = cylindersList[randomStartCylinder].GetComponent<connectionReferences>().connectionBottom;

            
            }
            else
            {
                previousCylinderBottom = fruitPassageOne.GetComponent<connectionReferences>().connectionBottom;

                cylindersList[randomStartCylinder].GetComponent<connectionReferences>().connectionTop.position = previousCylinderBottom.position;

                previousCylinderBottom = cylindersList[randomStartCylinder].GetComponent<connectionReferences>().connectionBottom;
                

            }

        }


        for(int i = 0; i < cylindersList.Count - 1; i++)
        {

           

           

            // Pick a random cylinder from the remaining numbers
            randomCylinderNumber = Random.Range(0, randomNumbersList.Count);



            //Debug.Log(this.gameObject.name + "  random cylinder  " + cylindersList[randomNumbersList[randomCylinderNumber]]);


            //Pick a random second cylinder and add it to the bottom of the first randomly selected cylinder
            cylindersList[randomNumbersList[randomCylinderNumber]].GetComponent<connectionReferences>().connectionTop.position = previousCylinderBottom.position;

            //Change the previous cylinder to the cylinder that was just connected
            previousCylinderBottom = cylindersList[randomNumbersList[randomCylinderNumber]].GetComponent<connectionReferences>().connectionBottom;

            

            //Remove the number from the random numbers
            randomNumbersList.Remove(randomNumbersList[randomCylinderNumber]);



        }

        if (this.gameObject.name == "Cylinder System One")
        {
            fruitPassageOne.GetComponent<connectionReferences>().connectionTop.position = previousCylinderBottom.position;
        }
        else
        {
            fruitPassageTwo.GetComponent<connectionReferences>().connectionTop.position = previousCylinderBottom.position;
        }


     

        //
        //finalPassageCylinder.GetComponent<connectionReferences>().connectionTop.position = previousCylinderBottom.position;


    }
   


}
