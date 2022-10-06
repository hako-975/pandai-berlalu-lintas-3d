using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTrigger : MonoBehaviour
{
    public int questTo = 1;
    LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
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
            levelManager.questionsPanel[questTo - 1].SetActive(true);
            CancelInvoke(); 
        }
    }
}