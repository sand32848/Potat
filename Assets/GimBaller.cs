using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimBaller : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] GameObject ballTracker;
    private GameObject cam => Camera.main.gameObject;

    void Update()
    {
        Vector3 targetDirection = new Vector3(ballTracker.transform.position.x, 0, ballTracker.transform.position.z) - new Vector3(transform.position.x, 0, transform.position.z);

        targetDirection.y = 0;

        //transform.position = new Vector3(player.transform.position.x,player.transform.position.y, player.transform.position.z - 3);

        //Vector3 lookPosition =  new Vector3(transform.position.x, 0, transform.position.z) - new Vector3(cam.transform.position.x, 0, cam.transform.position.z) ;
        //lookPosition = transform.InverseTransformPoint(lookPosition);
        //lookPosition.y = 0;

        transform.LookAt(targetDirection * 10);
        //print(lookPosition * 10);

        Debug.DrawRay(transform.position, targetDirection.normalized * 10);
    }
}
