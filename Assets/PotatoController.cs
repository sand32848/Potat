using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float flipSpeed;
    [SerializeField] private float camLookSpeed;
    [SerializeField] private GameObject ballTracker;

    private void Start()
    {
        rb.maxAngularVelocity = 5;
    }

    private void FixedUpdate()
    {
        Vector3 targetDirection =  new Vector3(ballTracker.transform.position.x,transform.position.y,ballTracker.transform.position.z) - transform.position;

        //// The step size is equal to speed times frame time.
        //float singleStep = camLookSpeed * Time.deltaTime;

        //// Rotate the forward vector towards the target direction by one step
        //Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        //// Draw a ray pointing at our target in
        //Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        if(InputController.Instance.movement.y <= -0.5 || InputController.Instance.movement.y >= 0.5)
        {
            Quaternion rotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, camLookSpeed * Time.deltaTime);
        }


        //rb.AddTorque(gimball.transform.forward * InputController.Instance.movement.y * moveSpeed);
      //  rb.AddTorque(Vector3.Cross(transform.forward, transform.up)  * InputController.Instance.movement.y * moveSpeed);

        print(Vector3.Cross(transform.forward, transform.up));

        rb.AddRelativeTorque(new Vector3(moveSpeed * InputController.Instance.movement.y, 0, 0));
        rb.AddTorque(Vector3.Cross(transform.right,Vector3.up) * -InputController.Instance.movement.x * flipSpeed);


        //transform.rotation = Quaternion.Euler
    }
}
