using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DateforCert : MonoBehaviour
{
    public Text dateTime;
    // Start is called before the first frame update
    void Start()
    {
        string time = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MMMM-yyyy");
        dateTime.text = time;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
