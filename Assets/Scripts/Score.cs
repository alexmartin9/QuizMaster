using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{

    int correctAnswers = 0;
    int allAnswers = 0;

    public string GetScoreText()
    {
        return ($"Score: {Mathf.RoundToInt(correctAnswers / (float)allAnswers * 100)} % ({correctAnswers} / {allAnswers})");
    }

    public string GetFinalScoreText()
    {
        return ($"Congratulations!\n You got a score of {Mathf.RoundToInt(correctAnswers / (float)allAnswers * 100)} % ({correctAnswers} / {allAnswers})");
    }

    public void correctAnswer()
    {
        ++correctAnswers;
    }

    public void Answer()
    {
        ++allAnswers;
    }

}



