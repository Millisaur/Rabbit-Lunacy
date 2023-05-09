using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<AudioManager>().Play("StartButton");
    }

    public void QuitGame()
    {
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("QuitButton");
    }
}
