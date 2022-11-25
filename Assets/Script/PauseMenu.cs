using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    static bool paused = false;
    public GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        paused = true;
        pauseMenu.gameObject.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        paused = false;
        pauseMenu.gameObject.SetActive(false);
    }

    public void BackToHub()
    {
        SceneManager.LoadScene("Level select 1");
        Time.timeScale = 1f;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
