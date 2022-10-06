using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public GameOverPanel gameOverPanel;

    public string gameOverMessage;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            gameOverPanel.GameOverMessage(gameOverMessage);
            gameOverPanel.gameObject.SetActive(true);
        }
    }
}
