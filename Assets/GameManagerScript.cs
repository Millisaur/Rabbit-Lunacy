using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;
    public GameObject victoryUI;
    private AudioManager audioManager;

    private void Start()
    {
        // Get a reference to the AudioManager object in the scene
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void CompleteLevel()
    {
        victoryUI.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("BossTheme");
        FindObjectOfType<AudioManager>().Play("VictoryTheme");
        //Debug.Log("Level Won");
    }

    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("ResumeScreen");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        FindObjectOfType<AudioManager>().Play("PauseScreen");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void gameOver()
    {
        FindObjectOfType<AudioManager>().Stop("StageTheme");
        FindObjectOfType<AudioManager>().Stop("BossTheme");
        FindObjectOfType<AudioManager>().Play("GameOver");
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FindObjectOfType<AudioManager>().Play("MenuButton");
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
