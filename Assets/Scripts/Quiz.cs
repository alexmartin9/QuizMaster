using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using System.Linq;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] List<QuestionsSO> questions = new List<QuestionsSO>();
    QuestionsSO currentQuestion;
    [SerializeField] TextMeshProUGUI questionText;

    [Header("Buttons-Answers")]
    [SerializeField] GameObject[] answerButtons;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite defaultAnswerSprite;
    bool answeredOnTime;

    [Header("Timer")]
    Timer timer;
    [SerializeField] Image timerImage;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    Score score;

    [Header("ProgressBar")]
    [SerializeField] Slider progressbar;

    [Header("EndGame")]
    public bool isComplete;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        score = FindObjectOfType<Score>();

        progressbar.maxValue = questions.Count;
        progressbar.value = 0;
    }
    void Start()
    {
        scoreText.text = "Score: ";
        isComplete = false;
    }



    void Update()
    {
        timerImage.fillAmount = timer.timerFraction;

        if (timer.loadNextQuestion)
        {
            answeredOnTime = false;
            nextQuestion();
            timer.loadNextQuestion = false;
        }
        if (!timer.isAnweringQuestion && !answeredOnTime) // if didnt anwer on time during Answer time
        {
            DisplayAnswer(-1);
            SetButtonState(false);
            scoreText.text = score.GetScoreText();

        }

    }

    void nextQuestion()
    {
        if (questions.Count == 0)
        {
            isComplete = true;
        }
        else
        {
            SetButtonState(true);
            SetDefaultButtonSprite();
            getRandomQuestion();
            DisplayQuestion();
            ++progressbar.value;
            score.Answer();

        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    void SetDefaultButtonSprite()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
    void getRandomQuestion()
    {

        int idxQuestion = Random.Range(0, questions.Count);
        currentQuestion = questions[idxQuestion];

        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }
    public void DisplayQuestion()
    {
        questionText.text = currentQuestion.getQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.getAnswer(i);
        }
    }

    void DisplayAnswer(int answerIndex)
    {
        Image buttonImage;
        if (answerIndex == currentQuestion.getCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[answerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            score.correctAnswer();

        }
        else
        {
            int correctAnswerIndex = currentQuestion.getCorrectAnswerIndex();

            questionText.text = $"Nooo! The correct answer was:\n {currentQuestion.getAnswer(correctAnswerIndex)}";
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }



    }

    public void AnswerSolver(int answerIndex)
    {
        answeredOnTime = true;
        DisplayAnswer(answerIndex);
        SetButtonState(false);
        timer.cancelTimer();
        scoreText.text = score.GetScoreText();

    }


}
