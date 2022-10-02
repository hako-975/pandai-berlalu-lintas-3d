using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueTrigger : MonoBehaviour
{
    public bool nextForward;
    public bool nextTurnRight;
    public bool nextTurnLeft;
    public bool nextBackward;

    public Car player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (nextForward)
            {
                player.CarForward();
            }
            gameObject.SetActive(false);
        }
    }
}
