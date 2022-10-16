using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public GameObject finishPanel;
    [HideInInspector]
    public bool isFinished = false;
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
            other.GetComponent<Animation>().Stop();

            sfx.FinishSFX();

            if (PlayerPrefsManager.instance.GetTempStarToBoolean(1, currentLevel) > 0)
            {
                PlayerPrefsManager.instance.SetStarToBoolean(1, currentLevel, 1);
            }

            if (PlayerPrefsManager.instance.GetTempStarToBoolean(2, currentLevel) > 0)
            {
                PlayerPrefsManager.instance.SetStarToBoolean(2, currentLevel, 1);
            }

            if (PlayerPrefsManager.instance.GetTempStarToBoolean(3, currentLevel) > 0)
            {
                PlayerPrefsManager.instance.SetStarToBoolean(3, currentLevel, 1);
            }

            // unlocked new level
            int levelAt = PlayerPrefsManager.instance.GetLevelAt();

            if (nextSceneLoad > levelAt)
            {
                PlayerPrefsManager.instance.SetLevelAt(nextSceneLoad);
            }

            isFinished = true;
        }
    }
}
