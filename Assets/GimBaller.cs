using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimBaller : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Update()
    {
        //transform.position = new Vector3(player.transform.position.x,player.transform.position.y, player.transform.position.z - 3);

        Vector3 lookPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        transform.LookAt(lookPosition);
    }
}
