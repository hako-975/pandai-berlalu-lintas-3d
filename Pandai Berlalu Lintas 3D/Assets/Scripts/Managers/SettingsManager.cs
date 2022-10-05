using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    /// <IMPORTANT>
    /// Jika ada pembaharuan atau penambahan fitur pada file ini
    /// Perbaharui juga file LoadSettingsOnStart.cs
    /// </IMPORTANT>

    [HideInInspector]
    public bool isSettings = false;

    public Button backButton;

    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;

    public Slider musicSlider;
    public Slider sfxSlider;

    public TMP_Dropdown graphicsDropdown;
    SFXManager sfx;

    // Start is called before the first frame update
    void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        musicSlider.value = PlayerPrefsManager.instance.GetVolumeMusic();
        sfxSlider.value = PlayerPrefsManager.instance.GetVolumeSFX();
        graphicsDropdown.value = PlayerPrefsManager.instance.GetGraphics();
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackButtonAction();
        }

        backButton.onClick.AddListener(delegate { BackButtonAction(); });
    }

    public void SetVolumeMusic(float volumeMusic)
    {
        // play sound effect
        sfx.PositiveButton();
        musicMixer.SetFloat("VolumeMusic", volumeMusic);
        PlayerPrefsManager.instance.SetVolumeMusic(volumeMusic);
    }

    public void SetVolumeSFX(float volumeSFX)
    {
        // play sound effect
        sfx.PositiveButton();
        musicMixer.SetFloat("VolumeMusic", volumeSFX);
        PlayerPrefsManager.instance.SetVolumeMusic(volumeSFX);
    }

    public void SetGraphics(int qualityIndex)
    {
        // play sound effect
        sfx.PositiveButton();
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefsManager.instance.SetGraphics(qualityIndex);
    }

    public void SetDefaultSetting()
    {
        // play sound effect
        sfx.PositiveButton();

        PlayerPrefsManager.instance.DeleteKey("VolumeMusic");
        PlayerPrefsManager.instance.DeleteKey("VolumeSFX");
        PlayerPrefsManager.instance.DeleteKey("QualityIndex");
    }

    void BackButtonAction()
    {
        isSettings = false;
        sfx.NegativeButton();
        gameObject.SetActive(false);
    }
}
