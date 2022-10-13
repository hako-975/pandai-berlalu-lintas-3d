using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionPanel : MonoBehaviour
{
    public StarTimerManager starTimerManager;
    public StarPanel starPanel;
    int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = PlayerPrefsManager.instance.GetCurrentLevel();
    }
    
    public void SetStarTimer(int starTo)
    {
        if (starTimerManager.getStarTimer)
        {
            PlayerPrefsManager.instance.SetTempStarToBoolean(starTo, currentLevel, 1);
            starPanel.SetStarPanel(starTo);
        }

        gameObject.SetActive(false);
    }
}
