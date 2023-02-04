using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolAudio : MonoBehaviour
{
    public AudioManager.SoundType soundType = AudioManager.SoundType.MASTER_MAIN;
    public AudioSource audioSource;

    private void OnEnable()
    {
        
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        AudioPooler.Instance.returnObject(soundType, this.gameObject);
    }
}
