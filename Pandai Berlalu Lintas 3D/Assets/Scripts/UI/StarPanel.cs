using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarPanel : MonoBehaviour
{
    public Image star1;
    public Image star2;
    public Image star3;
    
    int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = PlayerPrefsManager.instance.GetCurrentLevel();
        GetStarPanel();
    }


    public void SetStarPanel(int starTo)
    {
        if (starTo == 1)
        {
            if (PlayerPrefsManager.instance.GetTempStarToBoolean(1, currentLevel) > 0)
            {
                star1.color = Color.white;
            }
        }

        if (starTo == 2)
        {
            if (PlayerPrefsManager.instance.GetTempStarToBoolean(2, currentLevel) > 0)
            {
                star2.color = Color.white;
            }
        }

        if (starTo == 3)
        {
            if (PlayerPrefsManager.instance.GetTempStarToBoolean(3, currentLevel) > 0)
            {
                star3.color = Color.white;
            }
        }
    }

    public void GetStarPanel()
    {
        if (PlayerPrefsManager.instance.GetTempStarToBoolean(1, currentLevel) > 0)
        {
            star1.color = Color.white;
        }

        if (PlayerPrefsManager.instance.GetTempStarToBoolean(2, currentLevel) > 0)
        {
            star2.color = Color.white;
        }

        if (PlayerPrefsManager.instance.GetTempStarToBoolean(3, currentLevel) > 0)
        {
            star3.color = Color.white;
        }
    }
}
