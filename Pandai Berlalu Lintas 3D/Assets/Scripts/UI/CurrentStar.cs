using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentStar : MonoBehaviour
{
    TextMeshProUGUI textCurrentStar;
    SelectLevelManager selectLevelManager;
    [HideInInspector]
    public int currentStar = 0;

    // Start is called before the first frame update
    void Start()
    {
        selectLevelManager = FindObjectOfType<SelectLevelManager>();

        for (int i = 0; i < selectLevelManager.levelButtons.Length; i++)
        {
            if (PlayerPrefsManager.instance.GetStarToBoolean(1, i + 1) > 0)
            {
                currentStar += 1;
            }

            if (PlayerPrefsManager.instance.GetStarToBoolean(2, i + 1) > 0)
            {
                currentStar += 1;
            }

            if (PlayerPrefsManager.instance.GetStarToBoolean(3, i + 1) > 0)
            {
                currentStar += 1;
            }
        }

        textCurrentStar = GetComponent<TextMeshProUGUI>();
        textCurrentStar.text = currentStar.ToString(); 
    }
}
