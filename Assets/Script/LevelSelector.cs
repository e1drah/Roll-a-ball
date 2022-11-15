using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int levelNumber;
    public void LoadLevel()
    {
        switch(levelNumber)
        {
            case 1:
                SceneManager.LoadScene("Show case");
                break;
        }
    }
}
