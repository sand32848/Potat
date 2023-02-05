using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RayReciever : MonoBehaviour
{
    [SerializeField] private UnityEvent rayEvent;

    public void invokeEvent()
    {
        rayEvent.Invoke();
    }
}
