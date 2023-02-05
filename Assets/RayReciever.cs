using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RayReciever : MonoBehaviour
{
    [SerializeField] private UnityEvent rayEvent;

    public void invokeEvent()
    {
        rayEvent.Invoke();
    }
}
