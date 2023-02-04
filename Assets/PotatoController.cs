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
    [SerializeField] private GameObject parent ;

    [SerializeField] private GameObject posRight;
    [SerializeField] private GameObject posLeft;

    private GameObject gimball => GameObject.FindGameObjectWithTag("Gimball");

    private GameObject cam => Camera.main.gameObject;
    RaycastHit slopeHit;
    Vector3 slopeMoveDirection;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void FixedUpdate()
    {
        slopeMoveDirection = Vector3.ProjectOnPlane(gimball.transform.rotation.eulerAngles.normalized, slopeHit.normal);

        print(rb.velocity.normalized);

        if (onSlope())
        {
    
            rb.AddForce(slopeMoveDirection * InputController.Instance.movement.y * moveSpeed * 2f);
  
            Debug.DrawRay(transform.position, slopeMoveDirection * 5, Color.red);
            print(slopeMoveDirection);
        }
        else
        {
            rb.AddForce(cam.transform.forward * InputController.Instance.movement.y * moveSpeed);
        }

       // print(onSlope());

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
            transform.rotation = Quaternion.Lerp(transform.rotation, gimball.transform.rotation, Time.deltaTime * camLookSpeed);
        }

 
    }

    public bool onSlope()
    {
        if(Physics.Raycast(transform.position + new Vector3(0,0,0.01f),Vector3.down,out slopeHit, 4))
        {
            if (slopeHit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

  
}
