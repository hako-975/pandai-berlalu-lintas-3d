using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelManager : MonoBehaviour
{
    public Button[] levelButtons;
    
    public int TextMeshUGUI { get; private set; }

    SFXManager sfx;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefsManager.instance.GetStarToBoolean(1, 2));
        Debug.Log(PlayerPrefsManager.instance.GetStarToBoolean(2, 2));
        Debug.Log(PlayerPrefsManager.instance.GetStarToBoolean(3, 2));
        sfx = FindObjectOfType<SFXManager>();

        int levelAt = PlayerPrefsManager.instance.GetLevelAt();

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int level = i;

            level += 1;
            levelButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = level.ToString();

            levelButtons[i].interactable = false;

            if (levelAt > levelButtons.Length)
            {
                levelAt = levelButtons.Length;
            }

            for (int j = 0; j < levelAt; j++)
            {
                levelButtons[j].interactable = true;

                int l = j;

                // star yellow with index 0
                if (PlayerPrefsManager.instance.GetStarToBoolean(1, l + 1) > 0)
                {
                    levelButtons[j].transform
                    .GetChild(1).transform // must 1
                    .GetChild(0).transform // at star 1 to 3 start from 0 
                    .GetChild(0) // must 0
                    .GetComponentInChildren<Image>().color = Color.white;
                }

                // star yellow with index 1
                if (PlayerPrefsManager.instance.GetStarToBoolean(2, l + 1) > 0)
                {
                    levelButtons[j].transform
                    .GetChild(1).transform // must 1
                    .GetChild(1).transform // at star 1 to 3 start from 0 
                    .GetChild(0) // must 0
                    .GetComponentInChildren<Image>().color = Color.white;
                }

                // star yellow with index 2
                if (PlayerPrefsManager.instance.GetStarToBoolean(3, l + 1) > 0)
                {
                    levelButtons[j].transform
                    .GetChild(1).transform // must 1
                    .GetChild(2).transform // at star 1 to 3 start from 0 
                    .GetChild(0) // must 0
                    .GetComponentInChildren<Image>().color = Color.white;
                }

                levelButtons[j].onClick.AddListener(delegate { Level(l + 1); });
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (FindObjectOfType<BackButton>())
            {
                FindObjectOfType<BackButton>().BackButtonAction();
            }
            else
            {
                BackButtonAction();
            }
        }
    }

    public void BackButtonAction()
    {
        StartCoroutine(WaitSoundEffectToChangeScene(sfx.negativeButton, "MainMenu"));
    }

    public void Level(int level)
    {
        StartCoroutine(WaitSoundEffectToChangeScene(sfx.startButton, "Level" + level));
    }

    IEnumerator WaitSoundEffectToChangeScene(AudioSource buttonType, string nextScene)
    {
        buttonType.Play();

        yield return new WaitForSeconds(buttonType.clip.length);

        PlayerPrefsManager.instance.SetNextScene(nextScene);
    }
}
