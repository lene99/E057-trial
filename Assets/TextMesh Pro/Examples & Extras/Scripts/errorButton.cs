using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class errorButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject highlightButton;

    private void Start()
    {
        highlightButton.SetActive(false);
    }

    private void Update()
    {
        highlightButton.SetActive(true);
    }
}
