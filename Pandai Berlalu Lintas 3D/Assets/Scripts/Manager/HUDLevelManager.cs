using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class HUDLevelManager : MonoBehaviour
{
    public GameObject pausedPanel;
    public GameObject settingsPanel;
    public GameObject finishPanel;
    public GameObject gameOverPanel;

    public AudioMixer musicMixer;
    
    bool isPaused = false;
    bool isSettings = false;
    
    SFXManager sfx;
    FinishPoint finishPoint;
    GameOverTrigger gameOver;

    void Start()
    {
        gameOver = FindObjectOfType<GameOverTrigger>();
        sfx = FindObjectOfType<SFXManager>();
        finishPoint = FindObjectOfType<FinishPoint>();

        pausedPanel.SetActive(false);
        settingsPanel.SetActive(false);
        finishPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (finishPoint.isFinished == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (FindObjectOfType<BackButton>() == true)
                {
                    FindObjectOfType<BackButton>().BackButtonAction();
                }
                else if (isPaused == true && isSettings == true)
                {
                    isSettings = false;
                    sfx.NegativeButton();
                    settingsPanel.SetActive(false);
                }
                else if (isPaused == true)
                {
                    ResumeButton();
                }
                else
                {
                    PausedButton();
                }
            }
        }

        if (finishPoint.isFinished)
        {
            musicMixer.SetFloat("VolumeMusic", -100f);
            sfx.carMove.Stop();
            sfx.carTurn.Stop();
            sfx.carIdle.Stop();
            finishPanel.SetActive(true);
        }

        if (gameOver.isGameOver)
        {
            musicMixer.SetFloat("VolumeMusic", -100f);
        }
    }

    public void PausedButton()
    {
        Time.timeScale = 0;
        sfx.NegativeButton();
        pausedPanel.SetActive(true);
        isPaused = true;
        sfx.carMove.Stop();
        sfx.carTurn.Stop();
        sfx.carIdle.Stop();
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        sfx.PositiveButton();
        pausedPanel.SetActive(false);
        isPaused = false;
    }

    public void SettingsButton()
    {
        isSettings = true;
        sfx.PositiveButton();
        settingsPanel.SetActive(true);
    }
    
    public void RestartButton()
    {
        StartCoroutine(WaitSFX(SceneManager.GetActiveScene().name));
    }

    public void SelectLevelButton()
    {
        StartCoroutine(WaitSFX("SelectLevel"));
    }

    public void MainMenuButton()
    {
        StartCoroutine(WaitSFX("MainMenu"));
    }

    public void NextLevelButton()
    {
        StartCoroutine(WaitSFX("Level" + PlayerPrefsManager.instance.GetLevelAt()));
    }

    IEnumerator WaitSFX(string nextScene)
    {
        Time.timeScale = 1;
        sfx.PositiveButton();
        PlayerPrefsManager.instance.DeleteAllTempStarToBoolean();
        yield return new WaitForSeconds(sfx.positiveButton.clip.length);

        PlayerPrefsManager.instance.SetNextScene(nextScene);
    }
}
