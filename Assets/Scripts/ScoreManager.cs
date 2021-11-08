using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Linq;
using System;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public float score;
    public Text highScore;
    //private ScoreData sd;

    //void Awake()
    //{
    //    var json = PlayerPrefs.GetString("scores", "{}");
    //    sd = JsonUtility.FromJson<ScoreData>(json);
    //}

    void Start ()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            score += 1 * Time.deltaTime;
            scoreText.text = ((int)score).ToString();
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", (int)score);
                highScore.text = ((int)score).ToString();
            }
           
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore"); 
    }

    //public IEnumerable<Score> GetHighScores()
    //{
    //    return sd.scores.OrderByDescending(x => x.score);
    //}

    //public void AddScore(Score score)
    //{
    //    sd.scores.Add(score); 
    //}

    //private void OnDestroy()
    //{
    //    SaveScore(); 
    //}

    //public void SaveScore()
    //{
    //    var json = JsonUtility.ToJson(sd);
    //    Debug.Log(json);
    //    PlayerPrefs.SetString("scores", json);
    //}
}
