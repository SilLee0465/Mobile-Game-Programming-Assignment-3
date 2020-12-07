using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Unity()
    {
        SceneManager.LoadScene("TheFatRat - Unity");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
    }

    public void PlayFatRatUnity()
    {
        FindObjectOfType<AudioManager>().Play("TheFatRat - Unity");
    }

    public void StopMusic()
    {
        FindObjectOfType<AudioManager>().Stop("TheFatRat - Unity");
    }
}
