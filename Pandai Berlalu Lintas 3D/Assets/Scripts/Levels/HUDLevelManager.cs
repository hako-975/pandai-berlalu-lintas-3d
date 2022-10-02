using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDLevelManager : MonoBehaviour
{
    public void RestartGame()
    {
        PlayerPrefsManager.instance.SetNextScene(SceneManager.GetActiveScene().name);
    }
}
