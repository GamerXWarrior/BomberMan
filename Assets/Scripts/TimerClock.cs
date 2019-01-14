using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class TimerClock : MonoBehaviour
{
    int countdownStartValue = 150;
    public Text timerUI;
    public Text gameoverUI;
    public Button resetButton;
    public Button MainMenubutton;
    public Text Death1;
    public Text Death2;
    public AudioSource GameoverSound;
    public AudioSource stageSound;
  
    // Start is called before the first frame update
    void Start()
    {
        stageSound.Play();
        countdownTimer();
    }
    void countdownTimer()
    {
       
        Death2.text = "Player2 Wins:" + text.DeathCounter2;
        Death1.text = "Player1 Wins :" + text.DeathCounter1;
        if (countdownStartValue > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countdownStartValue);
            timerUI.text = "Time: " + spanTime.Minutes + ":" + spanTime.Seconds;
            countdownStartValue--;
            Invoke("countdownTimer", 1.0f);
            WinnerDeclare();

        }
        else
        {
            if (GameObject.Find("Player1") && GameObject.Find("Player2"))
            {
                Time.timeScale = 0;
                stageSound.Stop();
                GameoverSound.Play();
                gameoverUI.text = "Match Draw";
                MainMenubutton.gameObject.SetActive(true);
                resetButton.gameObject.SetActive(true);
            }
            else if (!GameObject.Find("Player1") && !GameObject.Find("Player2"))
            {
                Time.timeScale = 0;
                stageSound.Stop();
                GameoverSound.Play();
                gameoverUI.text = "Match Draw";
                resetButton.gameObject.SetActive(true);
                MainMenubutton.gameObject.SetActive(true);
            }
        }
    }

    void WinnerDeclare()
    {
       
        if (!GameObject.Find("Player1") && !GameObject.Find("Player2"))
        {
            Time.timeScale = 0;
            stageSound.Stop();
            GameoverSound.Play();
            gameoverUI.text = "Match Draw";
            resetButton.gameObject.SetActive(true);
            MainMenubutton.gameObject.SetActive(true);
        }
        else if (!GameObject.Find("Player1"))
        {
            Time.timeScale = 0;
            stageSound.Stop();
            GameoverSound.Play();
            text.DeathCounter2 = text.DeathCounter2 + 1;
            gameoverUI.text = "Player2 Won";
            Death2.text = "Player2 Wins:" + text.DeathCounter2;
            resetButton.gameObject.SetActive(true);
            MainMenubutton.gameObject.SetActive(true);
        }
        else if (!GameObject.Find("Player2"))
        {
            Time.timeScale = 0;
            stageSound.Stop();
            GameoverSound.Play();
            text.DeathCounter1 = text.DeathCounter1 + 1;
            gameoverUI.text = "Player1 Won";
            Death1.text = "Player1 Wins :" + text.DeathCounter1;
            resetButton.gameObject.SetActive(true);
            MainMenubutton.gameObject.SetActive(true);
        }
    }
    public void RestartMatch()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void MainMenuGo()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
