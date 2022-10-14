using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMoveTrigger : MonoBehaviour
{
    public NextMove nextMove;

    LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelManager.car.StopAnimation();
            nextMove.NextMoveCar();
        }
    }

    public void NextMoveDelay(float delay)
    {
        StartCoroutine(Delay(delay));
    }


    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        nextMove.NextMoveCar();
    }
}
