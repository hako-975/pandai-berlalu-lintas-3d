using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button startGame;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefsManager.instance.GetLevelAt() == 1)
        {
            startGame.onClick.AddListener(LevelAtSceneStartGame);
        }
        else
        {
            startGame.onClick.AddListener(LevelAtSceneContinueGame);
        }
    }

    void LevelAtSceneStartGame()
    {
        StartCoroutine(WaitSoundEffect("Level1"));
    }

    void LevelAtSceneContinueGame()
    {
        StartCoroutine(WaitSoundEffect("Level" + PlayerPrefsManager.instance.GetLevelAt()));
    }

    IEnumerator WaitSoundEffect(string sceneName)
    {
        //soundEffectUIManager.startButton.Play();
        //yield return new WaitForSeconds(soundEffectUIManager.startButton.clip.length);
        yield return null;
        PlayerPrefsManager.instance.SetNextScene(sceneName);
    }
}
