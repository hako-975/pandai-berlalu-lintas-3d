using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTrigger : MonoBehaviour
{
    public int questTo = 1;
    LevelManager levelManager;
    SFXManager sfx;

    void Start()
    {
        sfx = FindObjectOfType<SFXManager>();

        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sfx.SfxIdle();
            levelManager.car.StopAnimation();
            levelManager.questionsPanel[questTo - 1].SetActive(true);
        }
    }
}