using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowObstacle : MonoBehaviour
{
    [field:SerializeField] public bool linger { get; private set; }
    [field: SerializeField] public float duration { get; private set; }
}
