using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDLevelManager : MonoBehaviour
{
    public void RestartGame()
    {
        LoadingManager.instance.LoadGame(SceneManager.GetSceneAt(1).name);
    }

    public void MainMenu()
    {
        LoadingManager.instance.LoadGame("MainMenu");
    }
}
