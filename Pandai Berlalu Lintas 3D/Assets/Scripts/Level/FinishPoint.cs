using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public GameObject finishPanel;
    
    int nextSceneLoad;
    int currentLevel;

    SFXManager sfx;
    
    // Start is called before the first frame update
    void Start()
    {
        sfx = FindObjectOfType<SFXManager>();

        finishPanel.SetActive(false);
        currentLevel = PlayerPrefsManager.instance.GetCurrentLevel();
        nextSceneLoad = currentLevel + 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sfx.FinishSFX();

            // unlocked new level
            int levelAt = PlayerPrefsManager.instance.GetLevelAt();

            if (nextSceneLoad > levelAt)
            {
                PlayerPrefsManager.instance.SetLevelAt(nextSceneLoad);
            }

            finishPanel.SetActive(true);
        }
    }
}
