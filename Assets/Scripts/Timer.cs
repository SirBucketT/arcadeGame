using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timeRemaining = 180f; //Amount of seconds until game over.
    
        void Update()
        {
        
            timeRemaining -= Time.deltaTime;
            
            //If timer reaches zero load game over scene
            if (timeRemaining <= 0)
            {
                SceneManager.LoadScene("EndScene&Credit");
            }
        }
}
