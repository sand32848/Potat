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

        rb.AddForce(new Vector3(moveSpeed, 0, moveSpeed )* InputController.Instance.movement.y);

        if (InputController.Instance.movement.x == 1)
        {
            rb.AddForceAtPosition(Vector3.up * -flipSpeed, posRight.transform.position);
        }
        else if (InputController.Instance.movement.x == -1)
        {
            rb.AddForceAtPosition(Vector3.up * -flipSpeed, posLeft.transform.position);
        }


        if (InputController.Instance.movement.y != 0)
        {
            Quaternion rotation = Quaternion.LookRotation(targetDirection);
            rotation = Quaternion.Euler(transform.rotation.x, rotation.eulerAngles.y, transform.rotation.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, camLookSpeed * Time.deltaTime);
        }
    }
}
