using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool hasKey;
    public bool trapped;
    public bool gamePaused;
    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        trapped = true;
        gamePaused = true;
        
        Time.timeScale = 1.0f;
    }
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }
    public void TogglePauseGame()
     {
         gamePaused = !gamePaused;
         Time.timeScale = gamePaused == true ? 0.0f : 1.0f;
         GameUI.instance.TogglePauseMenu(gamePaused);
     }
}
