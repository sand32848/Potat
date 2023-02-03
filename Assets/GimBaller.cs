using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimBaller : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, player.transform.rotation.eulerAngles.y, 0);

        print(player.transform.rotation.y);
    }
}
