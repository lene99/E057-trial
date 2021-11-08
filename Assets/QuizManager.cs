using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject GoPanel;
    public GameObject BacktoMainmenu;
    public GameObject continueButton; 


    public Text QuestionTxt;
    public Text ScoreTxt;
    public Text ConstDisplayScore;
    public Text QuestionNumber;

    int totalQuestions = 0;
    public int score;
    public int qnnum = 1;

    private void Start()
    {
        continueButton.SetActive(false);
        totalQuestions = QnA.Count;
        BacktoMainmenu.SetActive(false);
        GoPanel.SetActive(false);
        generateQuestion();
        ConstDisplayScore.text = "Score: " + score + " / " + totalQuestions;
        QuestionNumber.text = "Qn " + qnnum;
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        if (score != totalQuestions)
        {
            QuizPanel.SetActive(false);
            GoPanel.SetActive(true);
            BacktoMainmenu.SetActive(false);
            ScoreTxt.text = "Please try again you got: " + score + "/" + totalQuestions;
        }
        else
        {
            QuizPanel.SetActive(false);
            GoPanel.SetActive(true);
            BacktoMainmenu.SetActive(true);
            continueButton.SetActive(true);
            ScoreTxt.text = "Congrats you got: " + score + "/" + totalQuestions;
        }
       
    }

    public void Correct()
    {
        score += 1;
        qnnum += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        ConstDisplayScore.text = "Score: " + score + " / " + totalQuestions;
        QuestionNumber.text = "Qn " + qnnum;
        generateQuestion();
        //StartCoroutine(WaitForNext());


    }
    public void Wrong()
    {
        qnnum += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        ConstDisplayScore.text = "Score: " + score + " / " + totalQuestions;
        QuestionNumber.text = "Qn " + qnnum;
        generateQuestion();
       // StartCoroutine(WaitForNext());


    }
    void SetAnswers()
    {

        for (int i = 0; i < options.Length; i++)
        {
            //options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
            
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();

            
        }
        else
        {
            Debug.Log("out of qn");
            GameOver();
            
        }
    }
    //public IEnumerator WaitForNext()
    //{
    //    yield return new WaitForSeconds(2);
    //    generateQuestion();
    //}
}
