using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
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
                yield return new WaitForEndOfFrame();
            }
        }
    }
}