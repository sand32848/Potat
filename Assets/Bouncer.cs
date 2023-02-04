using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] private float bounceForce;
    [SerializeField] private float reflectiveForce;
    [SerializeField] private bool reflective;
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.transform.TryGetComponent(out Rigidbody rb))
        {
            if (reflective)
            {
                rb.AddForce(Vector3.Reflect(rb.velocity,Vector3.right)  * reflectiveForce,ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }

        }
    }
}
