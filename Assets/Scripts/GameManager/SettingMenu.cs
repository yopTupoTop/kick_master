using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    //public AudioMixer audioMixer;

    [SerializeField] private Slider _slider;

    public void SetVolume(float volume)
    {
        //audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        SoundManager.Instance.ChangeMasterVolume(_slider.value);
        _slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMasterVolume(val));
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void Sound()
    {
        SoundManager.Instance.ToggleSound();
    }
}
