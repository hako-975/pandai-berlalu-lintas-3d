using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    SFXManager sfx;

    public GameOverPanel gameOverPanel;
    
    [TextArea(2, 3)]
    public string gameOverMessage;
    
    public string rightAnswer;

    [HideInInspector]
    public bool isGameOver = false;

    public bool isCarCrash = true;
    public bool isTicketed = false;

    void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
    }

    public void OverrideGameOverMessage()
    {
        gameOverPanel.GameOverMessage(gameOverMessage, rightAnswer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            gameOverPanel.GameOverMessage(gameOverMessage, rightAnswer);
            gameOverPanel.gameObject.SetActive(true);
            isGameOver = true;
            if (isCarCrash)
            {
                sfx.CarCrash();
            }

            if (isTicketed)
            {
                sfx.Whistle();

            }
            sfx.carMove.Stop();
            sfx.carTurn.Stop();
            sfx.carIdle.Stop();
        }
    }
}
