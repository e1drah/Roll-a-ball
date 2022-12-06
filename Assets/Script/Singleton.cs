using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance;

    public static bool[] levelComplete = new bool[10];
    public void Awake()
    {
        levelComplete[1] = false;
        levelComplete[2] = false;
        levelComplete[3] = false;
        levelComplete[4] = false;
        levelComplete[5] = false;
        levelComplete[6] = false;
        levelComplete[7] = false;
        levelComplete[8] = false;
        levelComplete[9] = false;

        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static void LevelComplete(int level)
    {
    }

}
