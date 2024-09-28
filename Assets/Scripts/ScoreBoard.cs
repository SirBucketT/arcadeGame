using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public TMP_Text frontScore;
    public TMP_Text backScore;
    void Start()
    {
        frontScore.text = PointManager.currentPoints.ToString();
        backScore.text = PointManager.currentPoints.ToString();
    }
}
