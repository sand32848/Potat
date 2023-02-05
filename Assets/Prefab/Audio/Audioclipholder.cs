using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audioclipholder : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClip;
    [SerializeField] AudioSettingClass audioprofile;
   
    private void Start()
    {
        
    }
    public void callaudio(int clipno)
    {
        AudioManager.PlayUISound(audioClip[clipno], audioprofile);
    }
}
