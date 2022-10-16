using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMoveTriggerBot : MonoBehaviour
{
    public Car carBot;
    public string animationName;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CarBot"))
        {
            carBot.StopAnimation();
            carBot.PlayAnimationName(animationName);
        }
    }
}
