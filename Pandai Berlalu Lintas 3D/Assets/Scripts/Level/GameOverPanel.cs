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
        gameObject.SetActive(true);
    }

    public void ActiveGameOverPanel(float delay)
    {
        StartCoroutine(Delay(delay));
    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(true);
    }
}
