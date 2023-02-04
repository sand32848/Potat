using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] private float pushForce;
    [SerializeField] Vector3 pushDirection;

    private void OnTriggerStay(Collider other)
    {

        if(other.TryGetComponent(out Rigidbody rb)) 
        {

            rb.AddForce(pushDirection * pushForce);
        }
    }
}
