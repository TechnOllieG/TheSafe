using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookHoverController : MonoBehaviour
{
    public GameObject mainObject;
    public GameObject displayObject;
    public GameObject laterMain;
    public GameObject laterDisplay;
    public GameObject earlierMain;
    public GameObject earlierDisplay;

    public float closedDisableHover;
    public float openDisableHover;

    void Update()
    {
        displayObject.transform.rotation = mainObject.transform.rotation;
        
        if (mainObject.transform.localEulerAngles.x > closedDisableHover)
        {
            laterMain.SetActive(true);
            laterDisplay.SetActive(false);
        }
        else
        {
            laterMain.SetActive(false);
            laterDisplay.SetActive(true);
        }
        
        if(mainObject.transform.localEulerAngles.x < openDisableHover)
        {
            earlierMain.SetActive(true);
            earlierDisplay.SetActive(false);
        }
        else
        {
            earlierMain.SetActive(false);
            earlierDisplay.SetActive(true);
        }
    }
}
