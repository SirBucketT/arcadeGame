using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public float maxValue = Timer.timeRemaining;
    public Slider timerSlider;
    public int TimerMaxRender;
    
    
    void Start()
    {
        if (Timer.timeRemaining != null)
        {
            timerSlider.maxValue = maxValue;
            timerSlider.value = Timer.timeRemaining;
            
        }
        else
        {
            Debug.LogError("Timer script is not assigned!");
        }
    
}

    // Update is called once per frame
    void Update()
    {
        if (Timer.timeRemaining != null)
        {
            timerSlider.value = Timer.timeRemaining;
        }
    }
}


