using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class TimerSinglePlayer : MonoBehaviour
{
    public Text TimerUI;
    public Text GameoverUI;
    int countdownValue = 150;
    public Button Reset;
    public Button MainMenu;
    public AudioSource GameOverSound;
    public AudioSource StageTheme;

    // Start is called before the first frame update
    void Start()
    {
         GameoverTime();
        StageTheme.Play();
    }

    void GameoverTime()
    {

        if (countdownValue > 0)
        {
            TimeSpan spantime = TimeSpan.FromSeconds(countdownValue);
            TimerUI.text = "Time: " + spantime.Minutes + ":" + spantime.Seconds;
            countdownValue--;
            Invoke("GameoverTime", 1.0f);
            playerDestroy();
        }
        else if(countdownValue == 0)
        {
            Time.timeScale = 0;
            GameoverUI.text = "Game Over";
            Reset.gameObject.SetActive(true);
            MainMenu.gameObject.SetActive(true);
        }
    }

    void playerDestroy()
    {
        if (!GameObject.Find("Player1"))
        {
            Time.timeScale = 0;
           GameoverUI.text = "Game Over";
            StageTheme.Stop();
            GameOverSound.Play();
            Reset.gameObject.SetActive(true);
            MainMenu.gameObject.SetActive(true);
        }
    }

    public void restartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }
    public void loadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
