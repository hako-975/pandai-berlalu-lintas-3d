using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuidePanel : MonoBehaviour
{
    public Button backButton;

    SFXManager sfx;

    // Start is called before the first frame update
    void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && FindObjectOfType<OpeningPanel>() == false)
        {
            BackButtonAction();
        }

        backButton.onClick.AddListener(delegate { BackButtonAction(); });
    }

    void BackButtonAction()
    {
        sfx.NegativeButton();
        gameObject.SetActive(false);
    }

    public void PositiveButton()
    {
        sfx.PositiveButton();
    }
}
