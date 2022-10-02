using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public TextMeshProUGUI bodyText;

    public void GameOverMessage(string message)
    {
        bodyText.text = message;
        gameObject.SetActive(true);
    }
}
