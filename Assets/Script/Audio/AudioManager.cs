using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public static class AudioManager
{
    public enum SoundType
    {
        MASTER_MAIN,
        BGM,
        AMBIENT,
        EFFECT,
        UI
    }
    public static string test;

    public static void PlaySound(AudioClip clip, float volume, bool loop, Transform sourceTransform)
    {
        GameObject soundGameObject = new GameObject("audio");
        soundGameObject.transform.position = sourceTransform.position;
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();

        audioSource.volume = volume;
        audioSource.loop = loop;
        audioSource.clip = clip;

        audioSource.Play();
    }
    public static void PlaySound(AudioClip clip)
    {
        GameObject soundGameObject = new GameObject("audio");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(clip);
    }
    public static void PlaySoundAtPosition(AudioClip audioClip, 
        AudioSettingClass _audioUISettings, Transform target, Quaternion rotation)
    {
        AudioPooler.Instance.SpawnFromPool(audioClip, _audioUISettings, target.position, rotation);
    }
    public static void PlaySoundAtPositionWithParent(AudioClip audioClip,
        AudioSettingClass _audioUISettings, Transform target, Quaternion rotation)
    {
        AudioPooler.Instance.SpawnPoolIntoParent(audioClip, _audioUISettings, target, rotation);
    }

    public static void PlayUISound(AudioClip audioClip, AudioSettingClass _audioUISettings)
    {
        AudioPooler.Instance.SpawnFromPool(audioClip, _audioUISettings, Vector3.zero, Quaternion.identity);
    }
}
[System.Serializable]
public class SoundAudioClip
{
    [SerializeField] private string _clipName => _audioClip.name;
    [SerializeField] private AudioManager.SoundType _soundType;
    [SerializeField] private AudioClip _audioClip;
    public string clipName => _clipName;
    public AudioManager.SoundType soundType => _soundType;
    public AudioClip audioClip => _audioClip;
}
[System.Serializable]
public class AudioSettingClass
{
    [SerializeField] private AudioManager.SoundType _soundType;
    [SerializeField][Range(0, 1)] private float _volume = 1;
    [SerializeField][Range(0, 1)] private float _pitch = 1;
    [SerializeField] private bool _loop = false;

    [Header("3D Sound Setting")]
    [SerializeField] private AudioRolloffMode _rolloffMode = AudioRolloffMode.Logarithmic;
    [SerializeField] private float _minDistance = 1;
    [SerializeField] private float _maxDistance = 500;

    #region Getter
    public AudioManager.SoundType soundType => _soundType;
    public float volume => _volume;
    public float pitch => _pitch;
    public bool loop => _loop;
    public AudioRolloffMode rolloffMode => _rolloffMode;
    public float minDistance => _minDistance;
    public float maxDistance => _maxDistance;
    #endregion

    public void SetAudioSetting(AudioSource audio)
    {
        audio.volume = _volume;
        audio.pitch = _pitch;
        audio.loop = _loop;
        audio.rolloffMode = rolloffMode;
        audio.minDistance = _minDistance;
        audio.maxDistance = _maxDistance;
    }
}