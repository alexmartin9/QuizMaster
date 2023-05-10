using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    Score score;
    [SerializeField] TextMeshProUGUI finalScoreText;

    private void Awake()
    {
        score = FindObjectOfType<Score>();
    }

    public void ShowFinalScore() {
        finalScoreText.text = score.GetFinalScoreText();
    }
}
