using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button startGame;

    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject quitPanel;
    public GameObject creditsPanel;
    public GameObject guidePanel;

    SFXManager sfx;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        quitPanel.SetActive(false);
        creditsPanel.SetActive(false);
        guidePanel.SetActive(false);

        sfx = FindObjectOfType<SFXManager>();

        if (PlayerPrefsManager.instance.GetLevelAt() == 1)
        {
            startGame.onClick.AddListener(LevelAtSceneStartGame);
        }
        else
        {
            startGame.onClick.AddListener(LevelAtSceneContinueGame);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // && FindObjectOfType<Guide>() == false
            if (FindObjectOfType<BackButton>() == false && FindObjectOfType<SettingsManager>() == false)
            {
                OpenQuitPanel();
            }
        }
    }
    
    public void SettingsButton()
    {
        sfx.PositiveButton();
        settingsPanel.SetActive(true);
    }

    public void GuideButton()
    {
        sfx.PositiveButton();
        guidePanel.SetActive(true);
    }

    public void OpenCreditsPanel()
    {
        sfx.PositiveButton();
        creditsPanel.SetActive(true);
    }
    public void RestartButton()
    {
        StartCoroutine(WaitSoundEffectToChangeScene(sfx.positiveButton, "Loading"));
    }

    public void OpenQuitPanel()
    {
        sfx.PositiveButton();
        quitPanel.SetActive(true);
    }
    
    public void QuitButton()
    {
        StartCoroutine(WaitSoundEffectToQuit());
        Debug.Log("Quit Game");
    }

    public void SelectLevelButton()
    {
        StartCoroutine(WaitSoundEffectToChangeScene(sfx.positiveButton, "SelectLevel"));
    }

    void LevelAtSceneStartGame()
    {
        StartCoroutine(WaitSoundEffect("Level1"));
    }

    void LevelAtSceneContinueGame()
    {
        StartCoroutine(WaitSoundEffect("Level" + PlayerPrefsManager.instance.GetLevelAt()));
    }

    IEnumerator WaitSoundEffectToChangeScene(AudioSource buttonType, string lastScene)
    {
        buttonType.Play();

        yield return new WaitForSeconds(buttonType.clip.length);

        LoadingManager.instance.LoadGame(lastScene);
    }

    IEnumerator WaitSoundEffectToQuit()
    {
        sfx.PositiveButton();

        yield return new WaitForSeconds(sfx.positiveButton.clip.length);

        Application.Quit();
    }

    IEnumerator WaitSoundEffect(string sceneName)
    {
        sfx.StartButton();
        yield return new WaitForSeconds(sfx.startButton.clip.length);
        LoadingManager.instance.LoadGame(sceneName);
    }
}
