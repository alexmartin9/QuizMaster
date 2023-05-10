using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quiz Question", fileName ="New Question")]
public class QuestionsSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Enter new question text";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctanswer;

    public string getQuestion() {
        return question; 
    }
    public int getCorrectAnswerIndex() {
        return correctanswer;
    }

    public string getAnswer(int idx) {
        return answers[idx];
    }


}
