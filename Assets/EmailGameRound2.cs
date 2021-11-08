using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EmailGameRound2 : MonoBehaviour
{

    public Text numberOfClicks;

    int numberOfErrors = 2;
    public Text errorText;
    public int score;
    public Text scoreText;
    int correctlypressed = 0;

    public Button errorButton1;
    public Button errorButton2;
    public Button errorButton3;
    public bool pressedButton = false;
    public GameObject nextRound;
    public GameObject music;
    public GameObject clearMail2;
    public GameObject retryButton; 
    public bool gameOn = false;

    // Update is called once per frame

    void Start()
    {
        score = 0;
        updateScoreUI();
        gameOn = true;
        GameOn(false);
        retryButton.SetActive(false); 
        nextRound.SetActive(false);
        clearMail2.SetActive(false);
        Button btn = errorButton1.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        Button btn2 = errorButton2.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick);

        Button btn3 = errorButton3.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClick);



    }
    public void addScore(int xAmount)
    {
        score += xAmount;
        updateScoreUI();
    }

    public void ReduceScore(int yAmount)
    {
        score -= yAmount;
        updateScoreUI();
    }

    public void updateScoreUI()
    {
        scoreText.color = Color.green;
        scoreText.text = "Points Accumulated = " + score.ToString();
    }
    void TaskOnClick()
    {
        pressedButton = true;
        // errorButton1.interactable = false; 
        GameOn(pressedButton);

    }

    void GameOn(bool pressedButton)
    {
        if (pressedButton == false)
        {
            if (Input.GetMouseButtonDown(0))
            {


                ReduceScore(200);

            }
        }
        else
        {
            addScore(700);

            if (numberOfErrors == 0)
            {
                if (score < 1500)
                {
                    errorText.text = "You need 900 points in order to proceed to next round.";
                    retryButton.SetActive(true);
                }
                else
                {
                    errorText.color = Color.green;
                    errorText.text = "Congratulations! You may proceed to the next round.";
                    gameOn = false;
                    nextRound.SetActive(true);
                    clearMail2.SetActive(true);
                }
                
            }
            else
            {
                errorText.color = Color.green;
                errorText.text = "Number of Errors = " + numberOfErrors.ToString();
                pressedButton = false;

                numberOfErrors--;

            }
        }
    }


    void Update()
    {
        if (gameOn)
        {
            GameOn(false);

        }

    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(music);
    }




}


