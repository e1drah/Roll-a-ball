using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene("Level select 1");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Controls()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
