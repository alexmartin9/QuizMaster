using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToAnswer = 30f;
    [SerializeField] float timeShowAnswer = 10f;

    public bool isAnweringQuestion = false;
    public bool loadNextQuestion = true;
    float timerValue;
    public float timerFraction;
     void Update()
    {
        UpdateTimer();
    }

    public void cancelTimer() { 
        timerValue = 0f; 
    }
    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if (timerValue > 0)
        {
            if (isAnweringQuestion)
            {
                timerFraction = timerValue / timeToAnswer;
            }
            else
            {
                timerFraction = timerValue / timeShowAnswer;
            }
        }
        else
        {
            if (isAnweringQuestion)
            {
                isAnweringQuestion = false;
                timerValue = timeShowAnswer;
            }
            else
            {
                isAnweringQuestion = true;
                timerValue = timeToAnswer;
                loadNextQuestion = true;
            }
        }
    }
}
