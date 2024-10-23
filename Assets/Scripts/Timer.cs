using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{

    public static float timeRemaining = 180f; //Amount of seconds until game over.
    public TMP_Text frontTimer;
    public TMP_Text backTimer;
    public TMP_Text frontScore;
    public TMP_Text backScore;
   
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
            
            
            frontScore.text = PointManager.currentPoints.ToString();
            backScore.text = PointManager.currentPoints.ToString();
        }
}
