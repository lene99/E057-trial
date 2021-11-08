using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionGame : MonoBehaviour
{
    
    [SerializeField]
    public Text gameText;

    [SerializeField]
    public Text timerscore;

    [SerializeField]
    public Text restarttext;

    //[SerializeField]
    //private SpriteRenderer whiteRect;

    private float reactionTime, startTime, randomDecayBeforeMearsuring;

    public GameObject startRestartButton;
    public GameObject crossButton;
    public GameObject emailScamImage;
    public GameObject restartButton;
    public GameObject blocker;
    public GameObject Homescreenbutton;

    private bool clockIsTicking, timerCanBeStopped;

    void Start()
    {
        timerscore.text = "";
        reactionTime = 0f;
        startTime = 0f;
        randomDecayBeforeMearsuring = 0f;
        gameText.text="Click to start";
        clockIsTicking = false;
        timerCanBeStopped = true;
        crossButton.SetActive(false);
        emailScamImage.SetActive(false);
        restartButton.SetActive(false);
        blocker.SetActive(false);
        Homescreenbutton.SetActive(false);
    }
    void Update()
    {
        
    }

    public IEnumerator StartMeasuring()
    {
        crossButton.SetActive(false);
        emailScamImage.SetActive(false);
        randomDecayBeforeMearsuring = Random.Range(0.5f, 5f);
        yield return new WaitForSeconds(randomDecayBeforeMearsuring);
        crossButton.SetActive(true);
        emailScamImage.SetActive(true);
        gameText.color = Color.green;
        startTime = Time.time;
        clockIsTicking = true;
        timerCanBeStopped = true;
    }
    public void startrestart()
    {
        blocker.SetActive(true);
        if (!clockIsTicking)
        {
            
            StartCoroutine("StartMeasuring");
            gameText.text = "Close the pop ups \n when it appears";
            gameText.color = Color.red;
            clockIsTicking = true;
            timerCanBeStopped = false;
            
            

        }
        else if (clockIsTicking && timerCanBeStopped)
        {
            /*
            StopCoroutine("start Measureing");
            reactionTime = Time.time - startTime;
            gameText.text = "Reaction time:\n" + reactionTime.ToString("N3") + "sec\n" + "Click to start again";
            clockIsTicking = false;
            */
            
            activateCrossButton();
            restartgame();
           
        }
        /*
        else if (clockIsTicking && !timerCanBeStopped)
        {
            StopCoroutine("Start Measuring");
            reactionTime = 0f;
            clockIsTicking = false;
            timerCanBeStopped = true;
            gameText.text = "Too early\n" + "Click to start again";
            
        }
        */
    }

    public void restartgame()
    {
        startRestartButton.SetActive(true);
        timerscore.text = "";
        reactionTime = 0f;
        startTime = 0f;
        randomDecayBeforeMearsuring = 0f;
        gameText.text = "Click to start";
        clockIsTicking = false;
        timerCanBeStopped = true;
        crossButton.SetActive(false);
        emailScamImage.SetActive(false);
        restartButton.SetActive(false);
        Homescreenbutton.SetActive(false);
        
        startrestart();
    }

    public void activateCrossButton()
    {
        StopCoroutine("start Measureing");
        reactionTime = Time.time - startTime;
        //gameText.text = "Reaction time:\n" + reactionTime.ToString("N3") + "sec\n";
        timerscore.text = "Reaction time:\n" + reactionTime.ToString("N3") + "sec\n";
        restarttext.text = "Click to restart";
        clockIsTicking = false;
        crossButton.SetActive(false);
        emailScamImage.SetActive(false);
        restartButton.SetActive(true);
        startRestartButton.SetActive(false);
        //timerscore.color = Color.green;
        gameText.text = "";
        Homescreenbutton.SetActive(true);

    }

    
    
}
