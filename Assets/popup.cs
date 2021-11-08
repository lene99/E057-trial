using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class popup : MonoBehaviour
{

    public GameObject scenepopup;

    public void Start()
    {
        scenepopup.SetActive(false);
    }

    public void OnMouseOver()
    {
        scenepopup.SetActive(true);
    }

    public void OnMouseExit()
    {
        scenepopup.SetActive(false);
    }
}
