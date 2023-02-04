using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioProfile_Name", menuName = "Profile/Audio Profile")]
public class AudioSourceProfile : ScriptableObject
{
    [SerializeField] private AudioSettingClass _audioSettingProfile;
    public AudioSettingClass audioSettingProfile => _audioSettingProfile;
}
