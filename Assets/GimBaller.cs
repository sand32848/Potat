using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimBaller : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Update()
    {
        transform.position = player.transform.position;
    }
}
