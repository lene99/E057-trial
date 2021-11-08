using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    
    public Text textComponent;
    [TextArea(3, 10)]
    public string[] lines;
    public float textSpeed;
    //private AudioSource source;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        
        //source = GetComponent<AudioSource>();
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(Typeline());
    }

    IEnumerator Typeline()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        //source.Play();
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(Typeline());
        }
       
    }

    //void AudioSource()
    //{
    //    if (textComponent.text == lines[index])
    //    {
    //        source.Stop();
    //    }
    //}
}
