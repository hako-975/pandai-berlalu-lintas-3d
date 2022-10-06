using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource startButton;
    public AudioSource positiveButton;
    public AudioSource negativeButton;
    public AudioSource finishSFX;

    public void StartButton()
    {
        startButton.Play();
    }

    public void PositiveButton()
    {
        positiveButton.Play();
    }

    public void NegativeButton()
    {
        negativeButton.Play();
    }

    public void FinishSFX()
    {
        finishSFX.Play();
    }
}
