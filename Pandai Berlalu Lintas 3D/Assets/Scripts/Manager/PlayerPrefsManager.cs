using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    #region Singleton
    public static PlayerPrefsManager instance;

    void Awake()
    {
        instance = this;
        SetCurrentLevel();
    }
    #endregion

    #region NextScene
    public string GetNextScene()
    {
        return PlayerPrefs.GetString("NextScene", "MainMenu");
    }

    public void SetNextScene(string nameScene)
    {
        Time.timeScale = 1;

        PlayerPrefs.SetString("NextScene", nameScene);
        SceneManager.LoadScene("Loading");
    }
    #endregion

    #region Level
    public int GetLevelAt()
    {
        return PlayerPrefs.GetInt("LevelAt", 1);
    }

    public int SetLevelAt(int level)
    {
        PlayerPrefs.SetInt("LevelAt", level);
        return GetLevelAt();
    }

    public int GetCurrentLevel()
    {
        return PlayerPrefs.GetInt("CurrentLevel", 0);
    }

    public int SetCurrentLevel()
    {
        // level 1, build index 1
        PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex);
        return GetCurrentLevel();
    }
    #endregion

    #region Star
    // get star boolean at level
    public int GetStarToBoolean(int starTo, int level)
    {
        return PlayerPrefs.GetInt("StarTo" + starTo + "Level" + level, 0);
    }

    // set star boolean at level
    public void SetStarToBoolean(int starTo, int level, int boolean)
    {
        PlayerPrefs.SetInt("StarTo" + starTo + "Level" + level, boolean);
    }

    // get temp star timer boolean at level
    public int GetTempStarTimerToBoolean(int level)
    {
        return PlayerPrefs.GetInt("TempStarTimerLevelBoolean" + level, 0);
    }

    // set temp star timer boolean at level
    public void SetTempStarTimerToBoolean(int level, int boolean)
    {
        PlayerPrefs.SetInt("TempStarTimerLevelBoolean" + level, boolean);
    }

    // delete all temp star boolean with current level
    public void DeleteAllTempStarTimerToBoolean()
    {
        for (int i = 1; i <= GetLevelAt() + 1; i++)
        {
            PlayerPrefs.DeleteKey("TempStarTimerLevelBoolean" + i);
        }
    }
    #endregion

    #region Settings
    public float GetVolumeMusic()
    {
        return PlayerPrefs.GetFloat("VolumeMusic", -5f);
    }

    public float SetVolumeMusic(float volumeMusic)
    {
        PlayerPrefs.SetFloat("VolumeMusic", volumeMusic);
        return GetVolumeMusic();
    }

    public float GetVolumeSFX()
    {
        return PlayerPrefs.GetFloat("VolumeSFX", -5f);
    }

    public float SetVolumeSFX(float volumeSFX)
    {
        PlayerPrefs.SetFloat("VolumeSFX", volumeSFX);
        return GetVolumeSFX();
    }

    public int GetGraphics()
    {
        // index of low
        return PlayerPrefs.GetInt("QualityIndex", 0);
    }

    public int SetGraphics(int qualityIndex)
    {
        PlayerPrefs.SetInt("QualityIndex", qualityIndex);
        return GetGraphics();
    }
    #endregion

    public void DeleteKey(string nameKey)
    {
        PlayerPrefs.DeleteKey(nameKey);
    }
}
