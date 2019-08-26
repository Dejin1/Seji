using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsAudio : MonoBehaviour
{
    public Slider MusicSlider;
    public Slider SFXSlider;
    public Text MV;
    public Text SFX;
    public float startVolume;

    // Update is called once per frame
    public void Start()
    {
        GameManager.MusicVolume = startVolume;
        GameManager.SFXVolume = startVolume;
        SFX.text = (startVolume * 100).ToString();
        MV.text = (startVolume * 100).ToString();
        MusicSlider.value = startVolume;
        SFXSlider.value = startVolume;
    }
    void Update()
    {
        MusicSlider.onValueChanged.AddListener(MusicSliderChangeValue);
        SFXSlider.onValueChanged.AddListener(SFXSliderChangeValue);
    }

    public void MusicSliderChangeValue(float musicVolume)
    {
        GameManager.MusicVolume = musicVolume;
        int VolumeTxt = (int)(musicVolume * 100);
        MV.text = VolumeTxt.ToString();
    }

    public void SFXSliderChangeValue(float sfxVolume)
    {
        GameManager.SFXVolume = sfxVolume;
        int sfxTxt = (int)(sfxVolume * 100);
        SFX.text = sfxTxt.ToString();
    }
}
