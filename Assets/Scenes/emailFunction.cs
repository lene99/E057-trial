using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class emailFunction : MonoBehaviour
{
    public Text scoreText; 
    public int score; 
    public bool pressedButton = false; 
    // Start is called before the first frame update
    void Start()
    {
          
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (pressedButton)
            {
                addScore(500);
            }
            else
            {
                ReduceScore(200);
            }

            if (score == 1500)
            {
                Debug.Log("Congrats!");
            }
        }
    }
}
