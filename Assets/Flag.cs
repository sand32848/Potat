using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flag : MonoBehaviour
{
    [SerializeField] private GameObject flag;
    [SerializeField] private List<ParticleSystem> particleList = new List<ParticleSystem>();

    // Update is called once per frame
    public void activateFlag()
    {
        flag.transform.DOScaleX(1,1f);

        for(int i = 0; i < particleList.Count; i++)
        {
            particleList[i].Play();
        }
    }
}
