using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timeRemaining = 180f; //Amount of seconds until game over.
    public TMP_Text frontTimer;
    public TMP_Text backTimer;
   
        void Update()
        {
        
            timeRemaining -= Time.deltaTime;
            
            //If timer reaches zero load game over scene
            if (timeRemaining <= 0)
            {
                SceneManager.LoadScene("EndScene&Credit");
            }
            
            frontTimer.text = timeRemaining.ToString() + ("S");
            backTimer.text = timeRemaining.ToString() + ("S");
        }
}
