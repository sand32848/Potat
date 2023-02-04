using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDebuff : MonoBehaviour
{
    [SerializeField] private bool debuffOn;
    [SerializeField] private float rayRange;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float speedLimiter;
    private float timer;

    private Rigidbody rb => GetComponent<Rigidbody>();

    private void Start()
    {
        print(rb.maxAngularVelocity);
        
    }

    void Update()
    {
        timer -= Time.deltaTime;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayRange, layerMask))
        {
            if (hit.transform.TryGetComponent(out SlowObstacle slow))
            {
                debuffOn = true;

                if (slow.linger)
                {
                    timer = slow.duration;
                }
            }
            else
            {
                debuffOn = false;
            }
        }
        else
        {
            debuffOn = false;
        }


        if (debuffOn || timer >= 0)
        {
            rb.maxAngularVelocity = speedLimiter;
        }
        else
        {
            rb.maxAngularVelocity = 50;
        }

        print(rb.maxAngularVelocity);
    }
}
