using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour {
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Slider master, music, sfx;
    public TMPro.TMP_Dropdown difficultyDropdown;

    void Start ()
    {
        LoadPrefs();
        List<string> options = new List<string>();
    }
    public void SetEffectsVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
        Debug.Log(volume);
    }

    public void SetMusicVolume(float volume)
    {
         audioMixer.SetFloat("MusicVolume", volume);
         PlayerPrefs.SetFloat("MusicVolume", volume);
         Debug.Log(volume);
    }
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
        Debug.Log(volume);
    }
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
        public void SetDiff (int diffIndex)
    {
        PlayerPrefs.SetInt("Difficulty", diffIndex);
    }
    void LoadPrefs()
    {
        master.value = PlayerPrefs.GetFloat("MasterVolume");
        music.value = PlayerPrefs.GetFloat("MusicVolume");
        sfx.value = PlayerPrefs.GetFloat("SFXVolume");
        difficultyDropdown.value = PlayerPrefs.GetInt("Difficulty");
    }

}
