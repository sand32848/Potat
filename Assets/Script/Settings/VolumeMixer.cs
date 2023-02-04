using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumeMixer : MonoBehaviour
{
    [Header("Volume Control")]
    [SerializeField] static VolumeMixer soundForce;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _ExposerString;

    [Header("Testing Sound")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _testSound;

    void Awake()
    {
        StartUpSet();
    }

    public void StartUpSet()
    {
        soundForce = this;
        // Set volume to match game data here
        if (!PlayerPrefs.HasKey(_ExposerString))
        {
            PlayerPrefs.SetFloat(_ExposerString, 1.0f);
        }
        _slider.value = PlayerPrefs.GetFloat(_ExposerString);
    }
    public void SetVolume(float sliderValue)
    {
        _audioMixer.SetFloat(_ExposerString, Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(_ExposerString, sliderValue);
    }
    public void PlayEffectOnce()
    {
        _audioSource.PlayOneShot(_testSound);
    }
}
