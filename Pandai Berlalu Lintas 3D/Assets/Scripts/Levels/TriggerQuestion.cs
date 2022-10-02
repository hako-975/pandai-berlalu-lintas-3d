using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQuestion : MonoBehaviour
{
    public GameObject questionPanel;
    
    void Start()
    {
        questionPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questionPanel.SetActive(true);
        }
    }
}