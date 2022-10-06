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
            InvokeRepeating("CheckAnimCar", 1, 0.1f);
        }
    }

    void CheckAnimCar()
    {
        if (levelManager.car.animationIsPlaying == false)
        {
            nextMove.NextMoveCar();
            CancelInvoke();
        }
    }
}
