using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Car car;
    public GameObject openingPanel;
    public Button startLevelButton;
    public Button.ButtonClickedEvent functionNextMoveCar;
    public GameObject[] questionsPanel;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < questionsPanel.Length; i++)
        {
            questionsPanel[i].SetActive(false);
        }

        openingPanel.SetActive(true);
        startLevelButton.onClick.AddListener(() => functionNextMoveCar.Invoke());
    }

    public void CloseOpeningPanel()
    {
        openingPanel.SetActive(false);
    }
}
