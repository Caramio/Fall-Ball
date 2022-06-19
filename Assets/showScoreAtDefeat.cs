using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using TMPro;

public class showScoreAtDefeat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = "You scored " + scoreChanger.scoreNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
