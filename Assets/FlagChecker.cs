using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagChecker : MonoBehaviour
{
    public GameObject flagOne;
    public GameObject flagTwo;
    public GameObject flagThree;
    public GameObject flagFour;
    public GameObject flagFive;
    public GameObject flagSix;
    public GameObject flagSeven;
    public GameObject flagEight;
    public GameObject flagNine;
    // Start is called before the first frame update
    void Start()
    {
        if (Singleton.levelComplete[1] == true)
        {
            flagOne.SetActive(true);
        }
        else
        {
            flagOne.SetActive(false);
        }
        if (Singleton.levelComplete[2] == true)
        {
            flagTwo.SetActive(true);
        }
        else
        {
            flagTwo.SetActive(false);
        }
        if (Singleton.levelComplete[3] == true)
        {
            flagThree.SetActive(true);
        }
        else
        {
            flagThree.SetActive(false);
        }
        if (Singleton.levelComplete[4] == true)
        {
            flagFour.SetActive(true);
        }
        else
        {
            flagFour.SetActive(false);
        }
        if (Singleton.levelComplete[5] == true)
        {
            flagFive.SetActive(true);
        }
        else
        {
            flagFive.SetActive(false);
        }
        if (Singleton.levelComplete[6] == true)
        {
            flagSix.SetActive(true);
        }
        else
        {
            flagSix.SetActive(false);
        }
        if (Singleton.levelComplete[7] == true)
        {
            flagSeven.SetActive(true);
        }
        else
        {
            flagSeven.SetActive(false);
        }
        if (Singleton.levelComplete[8] == true)
        {
            flagEight.SetActive(true);
        }
        else
        {
            flagEight.SetActive(false);
        }
        if (Singleton.levelComplete[9] == true)
        {
            flagNine.SetActive(true);
        }
        else
        {
            flagNine.SetActive(false);
        }
    }

    // Update is called once per frame

}
