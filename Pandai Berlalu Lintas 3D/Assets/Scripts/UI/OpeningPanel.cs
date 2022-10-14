using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningPanel : MonoBehaviour
{
    int currentPage;

    public GameObject[] pages;

    public GameObject previousButton;
    public GameObject nextButton;
    public GameObject closeButton;

    SFXManager sfx;

    // Start is called before the first frame update
    void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
        ResetPages();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentPage != 0)
            {
                PreviousButton();
            }
            else
            {
                CloseButton();
            }
        }
    }

    public void NextButton()
    {
        // if not end of pages
        if (currentPage != pages.Length - 1)
        {
            pages[currentPage].SetActive(false);

            currentPage += 1;
            pages[currentPage].SetActive(true);
        }

        sfx.PositiveButton();
        SetActiveButton();
    }

    public void PreviousButton()
    {
        // if not first of pages
        if (currentPage != 0)
        {
            pages[currentPage].SetActive(false);

            currentPage -= 1;
            pages[currentPage].SetActive(true);
        }

        sfx.NegativeButton();
        SetActiveButton();
    }

    void SetActiveButton()
    {
        // if current page == first
        if (currentPage == 0)
        {
            // disable prev
            previousButton.SetActive(false);

            // if current page not last
            if (currentPage != pages.Length - 1)
            {
                nextButton.SetActive(true);
                closeButton.SetActive(false);
            }
            else
            {
                closeButton.SetActive(true);
                nextButton.SetActive(false);
            }
        }
        // if current page == last
        else if (currentPage == pages.Length - 1)
        {
            closeButton.SetActive(true);

            // disable next
            nextButton.SetActive(false);

            // if current page not first
            if (currentPage != 0)
            {
                previousButton.SetActive(true);
            }
            else
            {
                previousButton.SetActive(false);
            }
        }
        else
        {
            if (currentPage == pages.Length - 1)
            {
                closeButton.SetActive(true);
            }
            else
            {
                closeButton.SetActive(false);
            }

            nextButton.SetActive(true);
            previousButton.SetActive(true);
        }
    }

    void ResetPages()
    {
        closeButton.SetActive(false);

        // set all deactive
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }

        currentPage = 0;

        if (currentPage == pages.Length - 1)
        {
            closeButton.SetActive(true);
        }

        // set first active
        pages[currentPage].SetActive(true);

        SetActiveButton();
    }

    public void CloseButton()
    {
        ResetPages();
        sfx.PositiveButton();
        gameObject.SetActive(false);
    }
}
