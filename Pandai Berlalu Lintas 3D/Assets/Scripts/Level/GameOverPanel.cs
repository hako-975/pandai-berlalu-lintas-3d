using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public TextMeshProUGUI bodyText;
    public TextMeshProUGUI rightAnswerText;
    
    public void GameOverMessage(string message = "", string rightAnswer = "")
    {
        bodyText.text = message;
        rightAnswerText.text = rightAnswer; 
    }

    public void ActiveGameOverPanel(float delay)
    {
        CancelInvoke();
        Invoke("GameObjectToActive", delay);
    }

    void GameObjectToActive()
    {
        gameObject.SetActive(true);
    }
}
