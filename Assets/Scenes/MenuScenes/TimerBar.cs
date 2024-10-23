using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public float maxValue = Timer.timeRemaining;
    public Slider timerSlider;
    public Slider TimeSlider2;
    
    
    
    void Start()
    {
        if (Timer.timeRemaining != null)
        {
            timerSlider.maxValue = maxValue;
            timerSlider.value = Timer.timeRemaining;
            
            TimeSlider2.maxValue = maxValue;
            TimeSlider2.value = Timer.timeRemaining;
            
        }
    }
    
    void Update()
    {
        if (Timer.timeRemaining != null)
        {
            timerSlider.value = Timer.timeRemaining;
            TimeSlider2.value = Timer.timeRemaining + 2;
        }
    }
}


