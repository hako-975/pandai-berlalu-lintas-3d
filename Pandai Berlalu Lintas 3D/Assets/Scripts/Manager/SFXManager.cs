using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource startButton;
    public AudioSource positiveButton;
    public AudioSource negativeButton;
    public AudioSource finishSFX;

    public AudioSource carMove;
    public AudioSource carTurn;
    public AudioSource carIdle;
    public AudioSource carCrash;

    public AudioSource whistle;

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

    public void CarMove()
    {
        carMove.Play();
    }

    public void CarTurn()
    {
        carTurn.Play();
    }

    public void CarIdle()
    {
        carIdle.Play();
    }

    public void CarCrash()
    {
        carCrash.Play();
    }

    public void Whistle()
    {
        whistle.Play();
    }

    public void SfxMove()
    {
        CarMove();
        carTurn.Stop();
        carIdle.Stop();
    }

    public void SfxIdle()
    {
        CarIdle();
        carMove.Stop();
        carTurn.Stop();
    }

    public void SfxTurn()
    {
        CarTurn();
        carMove.Stop();
        carIdle.Stop();
    }
}
