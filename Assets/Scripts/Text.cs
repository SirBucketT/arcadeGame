using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    public Text text;

    void Start()
    {
        //Text sets your text to say this message
        text.text = "Stork Game" + "Here are your instructions";
    }

    // void Update()
    // {
    //     //Press the space key to change the Text message
    //     if (Input.GetKey(KeyCode.Space))
    //     {
    //         text.text = "My text has now changed.";
    //     }
    // }

}