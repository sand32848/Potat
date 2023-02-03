using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject ballTracker;
    [SerializeField] private float lookSpeed;
    private GameObject potato => transform.GetComponent<GameObject>();
    private float cameraTorque;
    // Start is called before the first frame update


    private void FixedUpdate()
    {
        Vector3 targetDirection =  new Vector3(ballTracker.transform.position.x,transform.position.y,ballTracker.transform.position.z) - transform.position;

        float singleStep = lookSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection.normalized, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);

        rb.AddTorque(transform.forward * InputController.Instance.movement.y * moveSpeed);
    }
}
