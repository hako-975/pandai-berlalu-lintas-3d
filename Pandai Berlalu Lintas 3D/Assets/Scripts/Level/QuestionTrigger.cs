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
            levelManager.car.StopAnimation();
            levelManager.questionsPanel[questTo - 1].SetActive(true);
        }
    }
}