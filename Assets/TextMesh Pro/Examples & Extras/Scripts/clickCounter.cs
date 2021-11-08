using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickCounter : MonoBehaviour, IPointerClickHandler
{
    public bool Clicked; 
    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked = true; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Clicked = false;
    }

    private IEnumerator reset()
    {
        yield return new WaitForEndOfFrame();
        Clicked = false; 
    }
}
