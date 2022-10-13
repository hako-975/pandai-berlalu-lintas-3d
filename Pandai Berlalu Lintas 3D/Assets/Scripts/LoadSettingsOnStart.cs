using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LoadSettingsOnStart : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.SetQualityLevel(PlayerPrefsManager.instance.GetGraphics());
        musicMixer.SetFloat("VolumeMusic", PlayerPrefsManager.instance.GetVolumeMusic());
        sfxMixer.SetFloat("VolumeSFX", PlayerPrefsManager.instance.GetVolumeSFX());
    }
}
