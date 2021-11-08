using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUpRemoved : MonoBehaviour
{
    public GameObject popup;
    // Start is called before the first frame update
    public void RemovePopUp()
    {
        popup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
