using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public Image image;

    void Start()
    {
        StartCoroutine(LoadAsync(PlayerPrefsManager.instance.GetNextScene()));
    }

    IEnumerator LoadAsync(string nextScene)
    {
        AsyncOperation sync = SceneManager.LoadSceneAsync(nextScene);

        // set to main menu
        PlayerPrefsManager.instance.DeleteKey("NextScene");

        if (sync == null)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            while (!sync.isDone)
            {
                float progress = Mathf.Clamp01(sync.progress);
                image.fillAmount += progress;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}