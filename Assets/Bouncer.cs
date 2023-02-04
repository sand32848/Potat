using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] private float bounceForce;
  //  [SerializeField] private float reflectiveMultiplier;
    //private bool reflective;
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.transform.TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            //if (reflective)
            //{
            //    rb.AddForce()
            //}
            //else
            //{
                
            //}
            
        }
    }
}
