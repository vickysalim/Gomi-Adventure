using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeMusicSlider;
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            LoadMusic();
        }
        else
        {
            LoadMusic();
        }
    }

    public void ChangeVolumeSlider()
    {
        AudioListener.volume = volumeMusicSlider.value;
        SaveMusic();
    }

    private void LoadMusic()
    {
        try
        {
            volumeMusicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        } catch
        {
            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }
    }

    private void SaveMusic()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeMusicSlider.value);
    }
}
