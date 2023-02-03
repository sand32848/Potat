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

    [SerializeField] private GameObject posRight;
    [SerializeField] private GameObject posLeft;


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
        if(InputController.Instance.movement.y != 0)
        {
            //transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, timeCount * speed);
            Vector3 rotateAxisSide = Vector3.Cross(targetDirection, Vector3.down);
            rb.AddTorque(rotateAxisSide * camLookSpeed);

            //Quaternion rotation = Quaternion.LookRotation(targetDirection);
            //rotation = Quaternion.Euler(transform.rotation.x, rotation.eulerAngles.y, transform.rotation.z);
            //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, camLookSpeed * Time.deltaTime);
        }
  
        //Vector3 rotateAxisSide = Vector3.Cross(targetDirection.normalized, Vector3.up);
        //rb.AddTorque(camLookSpeed * rotateAxisSide);
        //rb.AddTorque(gimball.transform.forward * InputController.Instance.movement.y * moveSpeed);

        rb.AddForce(new Vector3(0, 0, moveSpeed * InputController.Instance.movement.y));

        if(InputController.Instance.movement.x == 1)
        {
            rb.AddForceAtPosition( Vector3.up * -flipSpeed, posRight.transform.position);
        }
        else if (InputController.Instance.movement.x == -1)
        {
            rb.AddForceAtPosition( Vector3.up * -flipSpeed, posLeft.transform.position);
        }

        //rb.AddTorque(new Vector3(moveSpeed * InputController.Instance.movement.y, 0, 0));
       // rb.AddTorque(Vector3.Cross(transform.right,Vector3.up) * -InputController.Instance.movement.x * flipSpeed);

    }
}
