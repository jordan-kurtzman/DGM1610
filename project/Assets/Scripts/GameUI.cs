using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [Header("Pause Menu")]
    public GameObject pauseMenu;
    public static GameUI instance;

    void Awake()
    {
        instance = this;
    }

    public void TogglePauseMenu(bool gamePaused)
    {
        pauseMenu.SetActive(gamePaused);
    }
    
    public void OnResumeButton()
    {
        GameManager.instance.TogglePauseGame();
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene("Bedroom", LoadSceneMode.Single);
    }

    public void OnNotesButton()
    {
        SceneManager.LoadScene("Notes", LoadSceneMode.Single);
    }

    public void OnBackButton()
    {
        SceneManager.LoadScene("title", LoadSceneMode.Single);
    }
}
