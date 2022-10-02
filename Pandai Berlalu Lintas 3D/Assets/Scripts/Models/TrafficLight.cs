using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public GameObject redColor;
    public GameObject yellowColor;
    public GameObject greenColor;
    
    public bool nextForward;
    public bool nextTurnRight;
    public bool nextTurnLeft;
    public bool nextBackward;

    public Car player;

    public void TriggerToRed(float delay)
    {
        greenColor.SetActive(true);
        StartCoroutine(DelayToRed(delay));
    }

    public void TriggerToGreen(float delay)
    {
        redColor.SetActive(true);
        StartCoroutine(DelayToGreen(delay));
    }

    void GreenColor()
    {
        greenColor.SetActive(true);
        yellowColor.SetActive(false);
    }

    IEnumerator DelayToRed(float delay)
    {
        yield return new WaitForSeconds(delay);
        greenColor.SetActive(false);
        yellowColor.SetActive(false);
        redColor.SetActive(true);
    }

    IEnumerator DelayToGreen(float delay)
    {
        yield return new WaitForSeconds(delay);
        redColor.SetActive(false);
        yellowColor.SetActive(true);
        Invoke("GreenColor", 1);
        if (nextForward)
        {
            Invoke("CarForward", 1);
        }
        // backward, turn left, turn right
    }

    void CarForward()
    {
        player.CarForward();
    }
}
