using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointSystem : MonoBehaviour
{

    public int score;
    public Text scoreText;

    // Use this for initialization
    void Start()
    {
        score = 0;
        updateScoreUI();
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

    void updateScoreUI()
    {
        scoreText.color = Color.green; 
        scoreText.text = "Points Accumulated = " + score.ToString();
    }


}