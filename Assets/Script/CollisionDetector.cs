using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    public UnityEvent events;
    public UnityEvent<GameObject> eventWithCollider;
    public LayerMask layerMask;

    private void OnTriggerEnter(Collider other)
    {
        if ((layerMask.value & (1 << other.transform.gameObject.layer)) > 0 || layerMask.value == 0)
        {
            events.Invoke();
            eventWithCollider.Invoke(other.gameObject);
        }

    }

	private void OnCollisionEnter(Collision collision)
	{
        if ((layerMask.value & (1 << collision.transform.gameObject.layer)) > 0 || layerMask.value == 0)
        {
            events.Invoke();
            eventWithCollider.Invoke(collision.gameObject);
        }

    }
}
